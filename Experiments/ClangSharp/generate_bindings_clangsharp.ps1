#requires -Version 7.0
<#
.SYNOPSIS
    Generate C# P/Invoke bindings for libtcod using ClangSharpPInvokeGenerator
.DESCRIPTION
    Generates bindings for all libtcod headers, producing one C# file per module.
    Uses ClangSharp for semantic understanding of C types, enums, callbacks, and struct layouts.
.EXAMPLE
    .\generate_bindings_clangsharp.ps1
#>

param(
    [string]$OutputDir = "GeneratedCode_ClangSharp",
    [string]$HeaderDir = "native/libtcod/src/libtcod",
    [string]$SDLDir = "native/SDL/include",
    [switch]$CleanPrevious = $true,
    [switch]$CleanDeprecated = $false
)

# Cleanup
if ($CleanPrevious -and (Test-Path $OutputDir)) {
    Write-Host "Removing previous output directory..." -ForegroundColor Cyan
    Remove-Item $OutputDir -Recurse -Force
}

# Create output directory
New-Item -ItemType Directory -Path $OutputDir -Force > $null

# Get all header files
$headers = @(Get-ChildItem $HeaderDir -Filter "*.h" -File).Name | Sort-Object

Write-Host "🔍 ClangSharp P/Invoke Generator for libtcod" -ForegroundColor Green
Write-Host "→ Headers: $($headers.Count) found in $HeaderDir"
Write-Host "→ Output: $(Resolve-Path $OutputDir)"
Write-Host ""

# Track results
$overallStartTime = Get-Date
$totalGenerated = 0
$totalFailed = 0
$times = @{}

foreach ($header in $headers) {
    $headerPath = "$HeaderDir\$header"
    $outputFile = "$OutputDir\$(($header -replace '\.h$', '') + '.cs')"
    
    $startTime = Get-Date
    
    Write-Host "📝 $header" -ForegroundColor Cyan -NoNewline
    
    try {
        # Generate bindings
        ClangSharpPInvokeGenerator `
            -F $HeaderDir `
            -f $header `
            -I $SDLDir `
            -o $outputFile `
            -l libtcod `
            -n libtcod_net `
            -m libtcod `
            -x c `
            --config latest-codegen `
            --config windows-types `
            --config exclude-funcs-with-body `
            --remap SDL_Event*=@void* SDL_Surface*=@void* SDL_Texture*=@void* SDL_Renderer*=@void* SDL_Window*=@void* SDL_Rect*=@void* `
            2>&1 | Out-Null
        
        $elapsedMs = ([DateTime]::Now - $startTime).TotalMilliseconds
        $times[$header] = $elapsedMs
        
        if (Test-Path $outputFile) {
            $lines = @(Get-Content $outputFile | Measure-Object -Line).Lines
            Write-Host " ✅ ($lines lines, ${elapsedMs}ms)" -ForegroundColor Green
            $totalGenerated++
        } else {
            Write-Host " ⚠️ (No output file created)" -ForegroundColor Yellow
            $totalFailed++
        }
    }
    catch {
        $elapsedMs = ([DateTime]::Now - $startTime).TotalMilliseconds
        Write-Host " ❌ (Error after ${elapsedMs}ms)" -ForegroundColor Red
        $totalFailed++
    }
}

# Post-process generated files to fix known ClangSharp output issues.
Write-Host ""
Write-Host "🔧 Post-processing generated files..." -ForegroundColor Cyan

$postProcessCount = 0
$removedObsoleteFunctionCount = 0
$removedObsoleteTypeCount = 0
$removedSdlStructCount = 0
$replacedSdlPointerCount = 0
$addedDoxygenDocCount = 0
$nativeTypeAttributePath = Join-Path $OutputDir "NativeTypeNameAttribute.cs"
$functionDocMap = @{}
$typeDocMap = @{}
$fieldDocMap = @{}
$c2ffiFunctionIndex = @{}
$c2ffiTypeIndex = @{}

function Strip-ObsoleteDeclarations {
    param(
        [string]$InputText,
        [ref]$RemovedFunctions,
        [ref]$RemovedTypes
    )

    if ([string]::IsNullOrEmpty($InputText)) {
        return $InputText
    }

    $lineBreak = if ($InputText.Contains("`r`n")) { "`r`n" } else { "`n" }
    $lines = [regex]::Split($InputText, "\r?\n")
    $result = New-Object System.Collections.Generic.List[string]

    $i = 0
    while ($i -lt $lines.Count) {
        $line = $lines[$i]
        $trimmed = $line.Trim()

        if ($trimmed -notmatch '^\[Obsolete(\(|\])') {
            $result.Add($line)
            $i++
            continue
        }

        $j = $i

        # Skip the entire [Obsolete(...)] attribute, including multiline string payloads.
        while ($j -lt $lines.Count) {
            if ($lines[$j] -match '\]\s*$') {
                $j++
                break
            }
            $j++
        }

        while ($j -lt $lines.Count -and [string]::IsNullOrWhiteSpace($lines[$j])) {
            $j++
        }
        while ($j -lt $lines.Count -and $lines[$j].TrimStart().StartsWith("[")) {
            $j++
        }

        if ($j -ge $lines.Count) {
            $result.Add($line)
            $i++
            continue
        }

        $declarationLine = $lines[$j].TrimStart()
        $isObsoleteStructOrEnum = $declarationLine -match '^(public|internal|protected|private).*\b(struct|enum)\b'

        # Match method declarations without being confused by delegate types in parameter lists.
        $isObsoleteFunction = $declarationLine -match '^(public|internal|protected|private)\s+(?:static\s+)?(?:unsafe\s+)?(?:extern\s+)?[^\(]+\('

        if (-not $isObsoleteStructOrEnum -and -not $isObsoleteFunction) {
            $result.Add($line)
            $i++
            continue
        }

        # Drop previously-emitted attribute lines (e.g. [DllImport]) bound to this declaration.
        while ($result.Count -gt 0) {
            $last = $result[$result.Count - 1]
            if ($last.TrimStart().StartsWith("[")) {
                $result.RemoveAt($result.Count - 1)
                continue
            }
            break
        }

        $end = $j
        if ($isObsoleteStructOrEnum) {
            $depth = 0
            $startedBody = $false

            for ($k = $j; $k -lt $lines.Count; $k++) {
                $openCount = [regex]::Matches($lines[$k], '\{').Count
                $closeCount = [regex]::Matches($lines[$k], '\}').Count

                if ($openCount -gt 0) {
                    $startedBody = $true
                    $depth += $openCount
                }
                if ($closeCount -gt 0) {
                    $depth -= $closeCount
                }

                if ($startedBody -and $depth -le 0) {
                    $end = $k
                    break
                }
            }

            $RemovedTypes.Value++
        }
        else {
            $depth = 0
            $startedBody = $false

            for ($k = $j; $k -lt $lines.Count; $k++) {
                if ($lines[$k].Contains(";")) {
                    $end = $k
                    break
                }

                $openCount = [regex]::Matches($lines[$k], '\{').Count
                $closeCount = [regex]::Matches($lines[$k], '\}').Count

                if ($openCount -gt 0) {
                    $startedBody = $true
                    $depth += $openCount
                }
                if ($closeCount -gt 0) {
                    $depth -= $closeCount
                }

                if ($startedBody -and $depth -le 0) {
                    $end = $k
                    break
                }
            }

            $RemovedFunctions.Value++
        }

        $i = $end + 1
    }

    return ($result -join $lineBreak)
}

function Strip-SdlStructDeclarations {
    param(
        [string]$InputText,
        [ref]$RemovedCount
    )

    if ([string]::IsNullOrEmpty($InputText)) {
        return $InputText
    }

    $types = @("SDL_Window", "SDL_Renderer", "SDL_Texture", "SDL_Surface", "SDL_Event", "SDL_Rect")

    $output = $InputText

    foreach ($typeName in $types) {
        # Remove the placeholder struct and any immediately preceding attribute lines.
        $pattern = '(?ms)^\s*(?:\[[^\]]+\]\s*\r?\n)*\s*public\s+partial\s+struct\s+' + [regex]::Escape($typeName) + '\s*\{\s*\}\s*'
        $matchCount = [regex]::Matches($output, $pattern).Count
        if ($matchCount -gt 0) {
            $RemovedCount.Value += $matchCount
            $output = [regex]::Replace($output, $pattern, "")
        }
    }

    return $output
}

function Get-DoxygenText {
    param(
        [System.Xml.XmlNode]$Node
    )

    if ($null -eq $Node) {
        return ""
    }

    $text = $Node.InnerText
    if ([string]::IsNullOrWhiteSpace($text)) {
        return ""
    }

    return ([regex]::Replace($text, '\s+', ' ')).Trim()
}

function Get-DoxygenSummary {
    param(
        [System.Xml.XmlNode]$Node
    )

    $summary = Get-DoxygenText $Node.SelectSingleNode("briefdescription")
    if (-not [string]::IsNullOrWhiteSpace($summary)) {
        return $summary
    }

    return (Get-DoxygenText $Node.SelectSingleNode("detaileddescription"))
}

function Get-LeafNameFromLocation {
    param(
        [string]$Location
    )

    if ([string]::IsNullOrWhiteSpace($Location)) {
        return ""
    }

    $pathOnly = $Location
    $colonIndex = $pathOnly.IndexOf(":")
    if ($colonIndex -gt 0) {
        $pathOnly = $pathOnly.Substring(0, $colonIndex)
    }

    return [System.IO.Path]::GetFileName(($pathOnly -replace '/', '\\'))
}

function Get-TopLevelParameterCount {
    param(
        [string]$Signature
    )

    if ([string]::IsNullOrWhiteSpace($Signature)) {
        return 0
    }

    $start = $Signature.IndexOf("(")
    if ($start -lt 0) {
        return 0
    }

    $depthParen = 1
    $depthAngle = 0
    $depthBracket = 0
    $end = -1
    for ($idx = $start + 1; $idx -lt $Signature.Length; $idx++) {
        $ch = $Signature[$idx]
        switch ($ch) {
            '(' { $depthParen++ }
            ')' {
                $depthParen--
                if ($depthParen -eq 0) {
                    $end = $idx
                    break
                }
            }
            '<' { $depthAngle++ }
            '>' { if ($depthAngle -gt 0) { $depthAngle-- } }
            '[' { $depthBracket++ }
            ']' { if ($depthBracket -gt 0) { $depthBracket-- } }
        }
    }

    if ($end -lt 0) {
        return 0
    }

    $paramSlice = $Signature.Substring($start + 1, $end - $start - 1).Trim()
    if ([string]::IsNullOrWhiteSpace($paramSlice) -or $paramSlice -eq "void") {
        return 0
    }

    $count = 1
    $depthAngle = 0
    $depthBracket = 0
    $depthParen = 0
    for ($idx = 0; $idx -lt $paramSlice.Length; $idx++) {
        $ch = $paramSlice[$idx]
        switch ($ch) {
            '<' { $depthAngle++ }
            '>' { if ($depthAngle -gt 0) { $depthAngle-- } }
            '[' { $depthBracket++ }
            ']' { if ($depthBracket -gt 0) { $depthBracket-- } }
            '(' { $depthParen++ }
            ')' { if ($depthParen -gt 0) { $depthParen-- } }
            ',' {
                if ($depthAngle -eq 0 -and $depthBracket -eq 0 -and $depthParen -eq 0) {
                    $count++
                }
            }
        }
    }

    return $count
}

function Add-DoxygenDocsToContent {
    param(
        [string]$InputText,
        [hashtable]$FunctionDocs,
        [hashtable]$TypeDocs,
        [hashtable]$FieldDocs,
        [string]$SourceHeaderName,
        [ref]$AddedCount
    )

    if ([string]::IsNullOrEmpty($InputText)) {
        return $InputText
    }

    $lineBreak = if ($InputText.Contains("`r`n")) { "`r`n" } else { "`n" }
    $lines = [regex]::Split($InputText, "\r?\n")
    $result = New-Object System.Collections.Generic.List[string]
    $result.AddRange($lines)

    $braceDepth = 0
    $pendingStructName = $null
    $structStack = New-Object System.Collections.Generic.List[object]

    $i = 0
    while ($i -lt $result.Count) {
        $line = $result[$i]
        $trimmed = $line.TrimStart()

        $isFunction = $false
        $name = $null
        $arity = 0

        if ($trimmed -match '^(public|internal|protected|private)\s+(?:unsafe\s+)?partial\s+struct\s+([A-Za-z_]\w*)\b') {
            $name = $matches[2]
            $pendingStructName = $name
        }
        elseif ($trimmed -match '^(public|internal|protected|private)\s+static\s+extern\s+[^\(]+\s+([A-Za-z_]\w*)\s*\(') {
            $isFunction = $true
            $name = $matches[2]
            $arity = Get-TopLevelParameterCount $trimmed
        }

        $docInfo = $null
        # Inject member docs for struct fields (for example TCOD_Noise.map / buffer).
        if ($structStack.Count -gt 0) {
            $activeStruct = $structStack[$structStack.Count - 1].Name

            if ($trimmed -notmatch '\(' -and $trimmed -notmatch '\b(struct|enum|class)\b' -and $trimmed -match '^(public|internal|protected|private)\s+[^;]*\s+([A-Za-z_@]\w*)\s*;\s*$') {
                $fieldName = $matches[2].TrimStart('@')
                $fieldDoc = $null

                $exactFieldKey = "$activeStruct|$fieldName|$SourceHeaderName"
                $wildcardFieldKey = "$activeStruct|$fieldName|*"
                if ($FieldDocs.ContainsKey($exactFieldKey)) {
                    $fieldDoc = $FieldDocs[$exactFieldKey]
                }
                elseif ($FieldDocs.ContainsKey($wildcardFieldKey)) {
                    $fieldDoc = $FieldDocs[$wildcardFieldKey]
                }

                if (-not [string]::IsNullOrWhiteSpace($fieldDoc)) {
                    $fieldInsertIndex = $i
                    while ($fieldInsertIndex -gt 0) {
                        $prevTrim = $result[$fieldInsertIndex - 1].Trim()
                        if ($prevTrim.StartsWith("[")) {
                            $fieldInsertIndex--
                            continue
                        }
                        break
                    }

                    $prevDocIndex = $fieldInsertIndex - 1
                    while ($prevDocIndex -ge 0 -and [string]::IsNullOrWhiteSpace($result[$prevDocIndex])) {
                        $prevDocIndex--
                    }

                    if (-not ($prevDocIndex -ge 0 -and $result[$prevDocIndex].TrimStart().StartsWith("///"))) {
                        $indent = [regex]::Match($line, '^\s*').Value
                        $fieldDocLine = "$indent/// $([System.Security.SecurityElement]::Escape($fieldDoc))"
                        $result.Insert($fieldInsertIndex, $fieldDocLine)
                        $AddedCount.Value++
                        $i++
                    }
                }
            }
        }

        $openCount = [regex]::Matches($line, '\{').Count
        $closeCount = [regex]::Matches($line, '\}').Count

        if (-not [string]::IsNullOrWhiteSpace($pendingStructName) -and $openCount -gt 0) {
            $structStack.Add(@{ Name = $pendingStructName; StartDepth = $braceDepth + 1 })
            $pendingStructName = $null
        }

        $braceDepth += $openCount
        $braceDepth -= $closeCount

        while ($structStack.Count -gt 0 -and $braceDepth -lt $structStack[$structStack.Count - 1].StartDepth) {
            $structStack.RemoveAt($structStack.Count - 1)
        }

        if ([string]::IsNullOrWhiteSpace($name)) {
            $i++
            continue
        }

        if ($isFunction) {
            $exactKey = "$name|$arity|$SourceHeaderName"
            $wildcardKey = "$name|$arity|*"
            if ($FunctionDocs.ContainsKey($exactKey)) {
                $docInfo = $FunctionDocs[$exactKey]
            }
            elseif ($FunctionDocs.ContainsKey($wildcardKey)) {
                $docInfo = $FunctionDocs[$wildcardKey]
            }
            elseif ($FunctionDocs.ContainsKey($name)) {
                $docInfo = $FunctionDocs[$name]
            }
        }
        else {
            $exactTypeKey = "$name|$SourceHeaderName"
            if ($TypeDocs.ContainsKey($exactTypeKey)) {
                $docInfo = $TypeDocs[$exactTypeKey]
            }
            elseif ($TypeDocs.ContainsKey($name)) {
                $docInfo = $TypeDocs[$name]
            }
        }

        if ($null -eq $docInfo) {
            $i++
            continue
        }

        $summary = $docInfo["Summary"]
        if ([string]::IsNullOrWhiteSpace($summary)) {
            $i++
            continue
        }

        $insertIndex = $i
        while ($insertIndex -gt 0) {
            $prevTrim = $result[$insertIndex - 1].Trim()
            if ($prevTrim.StartsWith("[")) {
                $insertIndex--
                continue
            }
            break
        }

        $checkIndex = $insertIndex - 1
        while ($checkIndex -ge 0 -and [string]::IsNullOrWhiteSpace($result[$checkIndex])) {
            $checkIndex--
        }
        if ($checkIndex -ge 0 -and $result[$checkIndex].TrimStart().StartsWith("///")) {
            $i++
            continue
        }

        $indent = [regex]::Match($line, '^\s*').Value
        $docLines = New-Object System.Collections.Generic.List[string]
        $docLines.Add("$indent/// <summary>")
        $docLines.Add("$indent/// $([System.Security.SecurityElement]::Escape($summary))")
        $docLines.Add("$indent/// </summary>")

        if ($isFunction) {
            $paramDocs = $docInfo["Params"]
            if ($paramDocs -is [System.Collections.IDictionary]) {
                foreach ($paramName in $paramDocs.Keys) {
                    $paramText = $paramDocs[$paramName]
                    if (-not [string]::IsNullOrWhiteSpace($paramText)) {
                        $docLines.Add("$indent/// <param name=`"$paramName`">$([System.Security.SecurityElement]::Escape($paramText))</param>")
                    }
                }
            }

            $returnText = $docInfo["Returns"]
            if (-not [string]::IsNullOrWhiteSpace($returnText) -and $trimmed -notmatch '\svoid\s+[A-Za-z_]\w*\s*\(') {
                $docLines.Add("$indent/// <returns>$([System.Security.SecurityElement]::Escape($returnText))</returns>")
            }
        }

        for ($d = $docLines.Count - 1; $d -ge 0; $d--) {
            $result.Insert($insertIndex, $docLines[$d])
        }

        $AddedCount.Value++
        $i += $docLines.Count + 1
    }

    return ($result -join $lineBreak)
}

$c2ffiJsonPath = "native/libtcod.json"
if (Test-Path $c2ffiJsonPath) {
    try {
        Write-Host "🧭 Loading c2ffi symbol index for doc matching..." -ForegroundColor Cyan
        $c2ffiItems = Get-Content $c2ffiJsonPath -Raw | ConvertFrom-Json -Depth 100

        foreach ($item in @($c2ffiItems)) {
            if ($item.tag -eq "function" -and -not [string]::IsNullOrWhiteSpace($item.name)) {
                $arity = @($item.parameters).Count
                $headerName = Get-LeafNameFromLocation $item.location
                if ([string]::IsNullOrWhiteSpace($headerName)) {
                    continue
                }

                $key = "$($item.name)|$arity"
                if (-not $c2ffiFunctionIndex.ContainsKey($key)) {
                    $c2ffiFunctionIndex[$key] = @{}
                }
                $c2ffiFunctionIndex[$key][$headerName] = $true
            }
            elseif (($item.tag -eq "struct" -or $item.tag -eq "union") -and -not [string]::IsNullOrWhiteSpace($item.name)) {
                $headerName = Get-LeafNameFromLocation $item.location
                if ([string]::IsNullOrWhiteSpace($headerName)) {
                    continue
                }

                if (-not $c2ffiTypeIndex.ContainsKey($item.name)) {
                    $c2ffiTypeIndex[$item.name] = @{}
                }
                $c2ffiTypeIndex[$item.name][$headerName] = $true
            }
        }

        Write-Host "✅ c2ffi index loaded: $($c2ffiFunctionIndex.Count) function signatures, $($c2ffiTypeIndex.Count) types" -ForegroundColor Green
    }
    catch {
        Write-Host "⚠️ Failed to read c2ffi json; falling back to Doxygen-only matching." -ForegroundColor Yellow
    }
}
else {
    Write-Host "⚠️ c2ffi json not found; using Doxygen-only matching." -ForegroundColor Yellow
}

if (Get-Command doxygen -ErrorAction SilentlyContinue) {
    Write-Host "📚 Building Doxygen XML docs for comment injection..." -ForegroundColor Cyan

    $doxygenOutputDir = Join-Path $OutputDir "doxygen_xml"
    $doxyfilePath = Join-Path $OutputDir "Doxyfile.generated"
    $headerInputPath = (Resolve-Path $HeaderDir).Path -replace '\\', '/'
    $fullOutputPath = (Resolve-Path $OutputDir).Path -replace '\\', '/'

    @"
PROJECT_NAME = "libtcod"
OUTPUT_DIRECTORY = "$fullOutputPath"
GENERATE_HTML = NO
GENERATE_LATEX = NO
GENERATE_XML = YES
XML_OUTPUT = doxygen_xml
RECURSIVE = NO
EXTRACT_ALL = NO
EXTRACT_STATIC = YES
EXTRACT_PRIVATE = YES
JAVADOC_AUTOBRIEF = YES
QT_AUTOBRIEF = NO
ALIASES = noop= \
          FuncDesc=@brief \
          FuncTitle=@noop \
          Param=@param \
          PageName=@noop \
          PageFather=@noop \
          PageTitle=@noop \
          PageCategory=@noop \
          PageDesc=@details \
          C=@noop \
          Cpp=@noop \
          Py=@noop \
          Lua=@noop \
          Cpp=@noop \
          CEx=@noop \
          CppEx=@noop \
          PyEx=@noop \
          LuaEx=@noop \
          Color=@noop \
          ColorTable=@noop \
          ColorCategory=@noop
INPUT = "$headerInputPath"
FILE_PATTERNS = *.h
ENABLE_PREPROCESSING = YES
MACRO_EXPANSION = YES
EXPAND_ONLY_PREDEF = YES
PREDEFINED = TCODLIB_API= \
             TCODLIB_CAPI= \
             "TCODLIB_FORMAT(int,int)=" \
             "TCOD_DEPRECATED(msg)=" \
             TCOD_DEPRECATED_NOMESSAGE= \
             TCOD_NODISCARD= \
             TCOD_PUBLIC= \
             TCOD_PRIVATE= \
             TCODLIB_BEGIN_IGNORE_DEPRECATIONS= \
             TCODLIB_END_IGNORE_DEPRECATIONS= \
             __restrict= \
             __cplusplus
EXPAND_AS_DEFINED = TCOD_CHARMAP_CP437_ \
                    TCOD_CHARMAP_TCOD_
QUIET = YES
WARN_IF_UNDOCUMENTED = NO
"@ | Set-Content $doxyfilePath

    try {
        doxygen $doxyfilePath 2>&1 | Out-Null

        if (Test-Path $doxygenOutputDir) {
            $xmlFiles = @(Get-ChildItem $doxygenOutputDir -Filter "*.xml" -File)
            foreach ($xmlFile in $xmlFiles) {
                [xml]$xml = Get-Content $xmlFile.FullName -Raw

                foreach ($compound in @($xml.SelectNodes("//compounddef[@kind='struct' or @kind='union' or @kind='class']"))) {
                    $typeName = (Get-DoxygenText $compound.SelectSingleNode("compoundname"))
                    if ([string]::IsNullOrWhiteSpace($typeName)) {
                        continue
                    }

                    $locationNode = $compound.SelectSingleNode("location")
                    $typeHeaderName = ""
                    if ($null -ne $locationNode) {
                        $typeHeaderName = Get-LeafNameFromLocation $locationNode.Attributes["file"].Value
                    }

                    if ($c2ffiTypeIndex.ContainsKey($typeName) -and -not [string]::IsNullOrWhiteSpace($typeHeaderName)) {
                        if (-not $c2ffiTypeIndex[$typeName].ContainsKey($typeHeaderName)) {
                            continue
                        }
                    }

                    foreach ($fieldMember in @($compound.SelectNodes(".//sectiondef[@kind='public-attrib' or @kind='public-static-attrib']/memberdef[@kind='variable']"))) {
                        $fieldName = Get-DoxygenText $fieldMember.SelectSingleNode("name")
                        $fieldSummary = Get-DoxygenSummary $fieldMember
                        if ([string]::IsNullOrWhiteSpace($fieldName) -or [string]::IsNullOrWhiteSpace($fieldSummary)) {
                            continue
                        }

                        if (-not [string]::IsNullOrWhiteSpace($typeHeaderName)) {
                            $fieldDocMap["$typeName|$fieldName|$typeHeaderName"] = $fieldSummary
                        }

                        $fieldDocMap["$typeName|$fieldName|*"] = $fieldSummary
                    }

                    $summary = Get-DoxygenSummary $compound
                    if ([string]::IsNullOrWhiteSpace($summary)) {
                        continue
                    }

                    if (-not [string]::IsNullOrWhiteSpace($typeHeaderName)) {
                        $typeDocMap["$typeName|$typeHeaderName"] = @{ Summary = $summary }
                    }

                    if (-not $typeDocMap.ContainsKey($typeName) -or [string]::IsNullOrWhiteSpace($typeDocMap[$typeName]["Summary"])) {
                        $typeDocMap[$typeName] = @{ Summary = $summary }
                    }

                }

                foreach ($member in @($xml.SelectNodes("//memberdef[@kind='function']"))) {
                    $functionName = (Get-DoxygenText $member.SelectSingleNode("name"))
                    if ([string]::IsNullOrWhiteSpace($functionName)) {
                        continue
                    }

                    $arity = Get-TopLevelParameterCount (Get-DoxygenText $member.SelectSingleNode("argsstring"))
                    $locationNode = $member.SelectSingleNode("location")
                    $functionHeaderName = ""
                    if ($null -ne $locationNode) {
                        $declfileAttr = $locationNode.Attributes["declfile"]
                        if ($null -ne $declfileAttr -and -not [string]::IsNullOrWhiteSpace($declfileAttr.Value)) {
                            $functionHeaderName = Get-LeafNameFromLocation $declfileAttr.Value
                        }
                        elseif ($null -ne $locationNode.Attributes["file"]) {
                            $functionHeaderName = Get-LeafNameFromLocation $locationNode.Attributes["file"].Value
                        }
                    }

                    $c2ffiKey = "$functionName|$arity"
                    if ($c2ffiFunctionIndex.ContainsKey($c2ffiKey) -and -not [string]::IsNullOrWhiteSpace($functionHeaderName)) {
                        if (-not $c2ffiFunctionIndex[$c2ffiKey].ContainsKey($functionHeaderName)) {
                            continue
                        }
                    }

                    $summary = Get-DoxygenSummary $member
                    $paramDocs = [ordered]@{}

                    foreach ($paramItem in @($member.SelectNodes(".//parameterlist[@kind='param']/parameteritem"))) {
                        $paramDescription = Get-DoxygenText $paramItem.SelectSingleNode("parameterdescription")
                        if ([string]::IsNullOrWhiteSpace($paramDescription)) {
                            continue
                        }

                        foreach ($paramNameNode in @($paramItem.SelectNodes("parameternamelist/parametername"))) {
                            $paramName = Get-DoxygenText $paramNameNode
                            if (-not [string]::IsNullOrWhiteSpace($paramName) -and -not $paramDocs.Contains($paramName)) {
                                $paramDocs[$paramName] = $paramDescription
                            }
                        }
                    }

                    $returnText = Get-DoxygenText $member.SelectSingleNode(".//simplesect[@kind='return']")
                    if ([string]::IsNullOrWhiteSpace($summary) -and $paramDocs.Count -eq 0 -and [string]::IsNullOrWhiteSpace($returnText)) {
                        continue
                    }

                    if (-not [string]::IsNullOrWhiteSpace($functionHeaderName)) {
                        $functionDocMap["$functionName|$arity|$functionHeaderName"] = @{
                            Summary = $summary
                            Params = $paramDocs
                            Returns = $returnText
                        }
                    }

                    $functionDocMap["$functionName|$arity|*"] = @{
                        Summary = $summary
                        Params = $paramDocs
                        Returns = $returnText
                    }

                    if (-not $functionDocMap.ContainsKey($functionName) -or [string]::IsNullOrWhiteSpace($functionDocMap[$functionName]["Summary"])) {
                        $functionDocMap[$functionName] = @{
                            Summary = $summary
                            Params = $paramDocs
                            Returns = $returnText
                        }
                    }
                }
            }

            Write-Host "✅ Doxygen docs loaded: $($typeDocMap.Count) types, $($functionDocMap.Count) functions" -ForegroundColor Green
        }
    }
    catch {
        Write-Host "⚠️ Doxygen generation failed; continuing without injected docs." -ForegroundColor Yellow
    }
    finally {
        if (Test-Path $doxyfilePath) {
            Remove-Item $doxyfilePath -Force
        }
    }
}
else {
    Write-Host "⚠️ Doxygen not found; skipping generated comment injection." -ForegroundColor Yellow
}

# Build and run the C# post-processor for wrapper generation and obsolete/SDL cleanup
Write-Host ""
Write-Host "🔧 Building BindingsPostProcessor..." -ForegroundColor Cyan
$postProcessorProject = "BindingsPostProcessor\BindingsPostProcessor.csproj"

# Try both x64 and default architecture paths
$postProcessorExe = "BindingsPostProcessor\bin\x64\Debug\net8.0\BindingsPostProcessor.exe"
if (-not (Test-Path $postProcessorExe)) {
    $postProcessorExe = "BindingsPostProcessor\bin\Debug\net8.0\BindingsPostProcessor.exe"
}

if (-not (Test-Path $postProcessorExe)) {
    Write-Host "📦 Compiling BindingsPostProcessor..." -ForegroundColor Cyan
    dotnet build $postProcessorProject -v q --configuration Debug 2>&1 | Out-Null
}

# Check again after build
$postProcessorExe = "BindingsPostProcessor\bin\x64\Debug\net8.0\BindingsPostProcessor.exe"
if (-not (Test-Path $postProcessorExe)) {
    $postProcessorExe = "BindingsPostProcessor\bin\Debug\net8.0\BindingsPostProcessor.exe"
}

if (Test-Path $postProcessorExe) {
    Write-Host "🚀 Running BindingsPostProcessor..." -ForegroundColor Cyan
    & $postProcessorExe $OutputDir
} else {
    Write-Host "⚠️ BindingsPostProcessor not found at expected paths; skipping C# post-processing." -ForegroundColor Yellow
}

if (-not (Test-Path $nativeTypeAttributePath)) {
    @"
using System;

namespace System.Runtime.InteropServices.Marshalling;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Delegate)]
public sealed class NativeTypeNameAttribute : Attribute
{
    public NativeTypeNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
"@ | Set-Content $nativeTypeAttributePath
}

# Final pass: Fix [NativeTypeName] imports and remaining SDL_Event cleanup
$generatedCsFiles = Get-ChildItem $OutputDir -Filter "*.cs" -File | Where-Object { $_.Name -ne "NativeTypeNameAttribute.cs" }
foreach ($file in $generatedCsFiles) {
    $content = Get-Content $file.FullName -Raw
    if ($null -eq $content) {
        $content = ""
    }
    $originalContent = $content

    # Inject C# XML docs sourced from Doxygen comments in native headers.
    $sourceHeader = "$($file.BaseName).h"
    $content = Add-DoxygenDocsToContent -InputText $content -FunctionDocs $functionDocMap -TypeDocs $typeDocMap -FieldDocs $fieldDocMap -SourceHeaderName $sourceHeader -AddedCount ([ref]$addedDoxygenDocCount)

    # Ensure files using [NativeTypeName] import its namespace.
    if (($content -match '\[NativeTypeName') -and -not ($content -match 'using System\.Runtime\.InteropServices\.Marshalling;')) {
        $namespaceIndex = $content.IndexOf("namespace ")
        if ($namespaceIndex -gt 0) {
            $prefix = $content.Substring(0, $namespaceIndex)
            $suffix = $content.Substring($namespaceIndex)
            if (-not $prefix.EndsWith([Environment]::NewLine)) {
                $prefix += [Environment]::NewLine
            }
            $content = $prefix + "using System.Runtime.InteropServices.Marshalling;" + [Environment]::NewLine + $suffix
        }
        else {
            $content = "using System.Runtime.InteropServices.Marshalling;" + [Environment]::NewLine + [Environment]::NewLine + $content
        }
    }

    # Avoid duplicate [StructLayout] on SDL_Event partial declarations across modules.
    if ($file.Name -eq "libtcod_int.cs") {
        $content = $content -replace '\[StructLayout\(LayoutKind\.Explicit\)\]\r?\n\s*(public partial struct SDL_Event)', '$1'
    }

    if ($content -ne $originalContent) {
        Set-Content $file.FullName $content
        $postProcessCount++
    }
}

Write-Host ""
Write-Host "✅ Finalized: $postProcessCount files (namespace imports, SDL_Event cleanup)" -ForegroundColor Green
Write-Host "🗒️ Added Doxygen XML docs: $addedDoxygenDocCount" -ForegroundColor Green

# Summary
Write-Host ""
Write-Host "═════════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "✅ Generated: $totalGenerated files" -ForegroundColor Green
Write-Host "❌ Failed: $totalFailed files" -ForegroundColor $(if ($totalFailed -eq 0) { 'Green' } else { 'Yellow' })
Write-Host "⏱️  Total time: $([math]::Round((([DateTime]::Now - $overallStartTime).TotalSeconds), 2))s" -ForegroundColor Cyan

# List output files
Write-Host ""
Write-Host "📂 Output files:" -ForegroundColor Cyan
$outputFiles = @(Get-ChildItem $OutputDir -File)
$outputFiles | ForEach-Object {
    $lines = @(Get-Content $_.FullName | Measure-Object -Line).Lines
    Write-Host "   $($_.Name) ($lines lines)"
}

Write-Host ""
Write-Host "✨ Done! ClangSharp bindings ready in: $OutputDir" -ForegroundColor Green

if(Test-Path $doxygenOutputDir) {
    Remove-Item $doxygenOutputDir -Recurse -Force
}

<#@"
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
        <Nullable>enable</Nullable>
        <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    </PropertyGroup>
</Project>
"@ | Set-Content "$OutputDir\test.csproj"#>