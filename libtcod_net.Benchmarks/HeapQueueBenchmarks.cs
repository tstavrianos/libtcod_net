using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using libtcod_net.TCOD;
using static libtcod_net.libtcod;
using IoPath = System.IO.Path;

namespace libtcod_net.Benchmarks;

public unsafe class HeapQueueBenchmarks
{
    private const int ItemCount = 1_048_576;
    private static bool _nativeLibrariesLoaded;

    private readonly int[] _priorities = new int[ItemCount];
    private readonly QueueItem[] _items = new QueueItem[ItemCount];

    private PriorityQueue<QueueItem, int> _priorityQueue = null!;
    private HeapQueue<QueueItem> _heapQueue = null!;
    private TCOD_Heap* _rawHeap;

    [GlobalSetup]
    public void Setup()
    {
        ConfigureNativeLibraryPath();

        var random = new System.Random(12345);
        for (var i = 0; i < ItemCount; i++)
        {
            _priorities[i] = random.Next();
            _items[i] = new QueueItem { Value = i };
        }

        _priorityQueue = new PriorityQueue<QueueItem, int>(ItemCount);
        _heapQueue = HeapQueue<QueueItem>.Create();

        _rawHeap = (TCOD_Heap*)NativeMemory.Alloc((nuint)sizeof(TCOD_Heap));
        *_rawHeap = default;
        var ret = TCOD_heap_init(_rawHeap, (ulong)sizeof(QueueItem));
        if (ret < 0)
        {
            NativeMemory.Free(_rawHeap);
            _rawHeap = null;
            throw new TCODException("Failed to initialize raw TCOD heap", (TCOD_Error)ret);
        }
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _heapQueue.Dispose();

        if (_rawHeap != null)
        {
            TCOD_heap_uninit(_rawHeap);
            NativeMemory.Free(_rawHeap);
            _rawHeap = null;
        }
    }

    [Benchmark]
    public int PriorityQueuePushPop()
    {
        FillPriorityQueue();

        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            var item = _priorityQueue.Dequeue();
            checksum += item.Value;
        }

        return checksum;
    }

    [Benchmark]
    public int HeapQueueWrapperPushPop()
    {
        FillHeapQueueWrapper();

        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            _heapQueue.Pop(out var item);
            checksum += item.Value;
        }

        return checksum;
    }

    [Benchmark]
    public int HeapQueueNativePushPop()
    {
        FillHeapQueueNative();

        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            QueueItem item = default;
            TCOD_minheap_pop(_rawHeap, &item);
            checksum += item.Value;
        }

        return checksum;
    }

    [Benchmark]
    public int PriorityQueuePushOnly()
    {
        FillPriorityQueue();
        var first = _priorityQueue.Dequeue();
        return first.Value;
    }

    [Benchmark]
    public int HeapQueueWrapperPushOnly()
    {
        FillHeapQueueWrapper();
        _heapQueue.Pop(out var first);
        return first.Value;
    }

    [Benchmark]
    public int HeapQueueNativePushOnly()
    {
        FillHeapQueueNative();
        QueueItem first = default;
        TCOD_minheap_pop(_rawHeap, &first);
        return first.Value;
    }

    [IterationSetup(Target = nameof(PriorityQueuePopOnly))]
    public void SetupPriorityQueuePopOnly() => FillPriorityQueue();

    [Benchmark]
    public int PriorityQueuePopOnly()
    {
        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            var item = _priorityQueue.Dequeue();
            checksum += item.Value;
        }

        return checksum;
    }

    [IterationSetup(Target = nameof(HeapQueueWrapperPopOnly))]
    public void SetupHeapQueueWrapperPopOnly() => FillHeapQueueWrapper();

    [Benchmark]
    public int HeapQueueWrapperPopOnly()
    {
        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            _heapQueue.Pop(out var item);
            checksum += item.Value;
        }

        return checksum;
    }

    [IterationSetup(Target = nameof(HeapQueueNativePopOnly))]
    public void SetupHeapQueueNativePopOnly() => FillHeapQueueNative();

    [Benchmark]
    public int HeapQueueNativePopOnly()
    {
        var checksum = 0;
        for (var i = 0; i < ItemCount; i++)
        {
            QueueItem item = default;
            TCOD_minheap_pop(_rawHeap, &item);
            checksum += item.Value;
        }

        return checksum;
    }

    private void FillPriorityQueue()
    {
        _priorityQueue.Clear();
        for (var i = 0; i < ItemCount; i++)
        {
            _priorityQueue.Enqueue(_items[i], _priorities[i]);
        }
    }

    private void FillHeapQueueWrapper()
    {
        _heapQueue.Clear();
        for (var i = 0; i < ItemCount; i++)
        {
            _heapQueue.Push(ref _items[i], _priorities[i]);
        }
    }

    private void FillHeapQueueNative()
    {
        TCOD_heap_clear(_rawHeap);
        for (var i = 0; i < ItemCount; i++)
        {
            fixed (QueueItem* itemPtr = &_items[i])
            {
                var ret = TCOD_minheap_push(_rawHeap, _priorities[i], itemPtr);
                if (ret < 0)
                {
                    throw new TCODException(
                        "Failed to push item onto raw TCOD heap",
                        (TCOD_Error)ret
                    );
                }
            }
        }
    }

    private static void ConfigureNativeLibraryPath()
    {
        if (_nativeLibrariesLoaded)
        {
            return;
        }

        var solutionRoot = TryFindSolutionRoot();
        if (solutionRoot == null)
        {
            return;
        }

        var candidate = IoPath.Combine(solutionRoot, "Requirements", "Release", "Bin", "x64");
        if (!Directory.Exists(candidate))
        {
            return;
        }

        var path = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
        if (!path.Contains(candidate, StringComparison.OrdinalIgnoreCase))
        {
            Environment.SetEnvironmentVariable("PATH", candidate + IoPath.PathSeparator + path);
        }

        PreloadLibrary(candidate, "zlib1.dll");
        PreloadLibrary(candidate, "utf8proc.dll");
        PreloadLibrary(candidate, "SDL3.dll");
        PreloadLibrary(candidate, "libtcod.dll");
        _nativeLibrariesLoaded = true;
    }

    private static void PreloadLibrary(string directory, string fileName)
    {
        var fullPath = IoPath.Combine(directory, fileName);
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"Required native library not found: {fullPath}");
        }

        NativeLibrary.Load(fullPath);
    }

    private static string? TryFindSolutionRoot()
    {
        var probes = new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() };

        foreach (var probe in probes)
        {
            var current = new DirectoryInfo(probe);
            while (current != null)
            {
                var solutionFile = IoPath.Combine(current.FullName, "libtcod_net.slnx");
                if (File.Exists(solutionFile))
                {
                    return current.FullName;
                }

                current = current.Parent;
            }
        }

        return null;
    }

    private struct QueueItem
    {
        public int Value;
    }
}
