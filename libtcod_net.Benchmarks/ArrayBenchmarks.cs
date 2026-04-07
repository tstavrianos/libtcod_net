using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace libtcod_net.Benchmarks;

public class ArrayBenchmarks
{
    private int _seed;
    private const int ArrayWidth = 100;
    private const int ArrayHeight = 100;
    private const int ElementChecks = 20;
    private double[,] _rectangularArray;
    private double[] _flatArray;
    private double[][] _jaggedArray;

    [GlobalSetup]
    public void Setup()
    {
        _seed = Random.Shared.Next();
        _rectangularArray = new double[ArrayWidth, ArrayHeight];
        _flatArray = new double[ArrayWidth * ArrayHeight];
        _jaggedArray = new double[ArrayHeight][];
        for (var i = 0; i < ArrayHeight; i++)
        {
            _jaggedArray[i] = new double[ArrayWidth];
        }

        var random = new Random(_seed);
        for (var y = 0; y < ArrayHeight; y++)
        for (var x = 0; x < ArrayWidth; x++)
        {
            var value = random.NextDouble();
            _rectangularArray[x, y] = value;
            _flatArray[x + ArrayWidth * y] = value;
            _jaggedArray[y][x] = value;
        }
    }

    [Benchmark]
    public double SumRectangularArray()
    {
        var sum = 0.0;
        for (var x = 0; x < ArrayWidth; x++)
        {
            for (var y = 0; y < ArrayHeight; y++)
            {
                sum += _rectangularArray[x, y];
            }
        }

        return sum;
    }

    [Benchmark]
    public double SumFlatArray()
    {
        var sum = 0.0;
        for (var i = 0; i < _flatArray.Length; i++)
        {
            sum += _flatArray[i];
        }

        return sum;
    }

    [Benchmark]
    public double SumJaggedArray()
    {
        var sum = 0.0;
        for (var y = 0; y < ArrayHeight; y++)
        for (var x = 0; x < ArrayWidth; x++)
        {
            sum += _jaggedArray[y][x];
        }

        return sum;
    }

    [Benchmark]
    public void FillRectangularArray()
    {
        var random = new Random(_seed);
        for (var x = 0; x < ArrayWidth; x++)
        {
            for (var y = 0; y < ArrayHeight; y++)
            {
                _rectangularArray[x, y] = random.NextDouble();
            }
        }
    }

    [Benchmark]
    public void FillFlatArray()
    {
        var random = new Random(_seed);
        for (var i = 0; i < _flatArray.Length; i++)
        {
            _flatArray[i] = random.NextDouble();
        }
    }

    [Benchmark]
    public void FillJaggedArray()
    {
        var random = new Random(_seed);
        for (var y = 0; y < ArrayHeight; y++)
        for (var x = 0; x < ArrayWidth; x++)
        {
            _jaggedArray[y][x] = random.NextDouble();
        }
    }

    [Benchmark]
    public void CheckRectangularArray()
    {
        var random = new Random(_seed);
        for (var i = 0; i < ElementChecks; i++)
        {
            var x = random.Next(ArrayWidth);
            var y = random.Next(ArrayHeight);
            var value = _rectangularArray[x, y];
        }
    }

    [Benchmark]
    public void CheckFlatArray()
    {
        var random = new Random(_seed);
        for (var i = 0; i < ElementChecks; i++)
        {
            var index = random.Next(_flatArray.Length);
            var value = _flatArray[index];
        }
    }

    [Benchmark]
    public void CheckJaggedArray()
    {
        var random = new Random(_seed);
        for (var i = 0; i < ElementChecks; i++)
        {
            var x = random.Next(ArrayWidth);
            var y = random.Next(ArrayHeight);
            var value = _jaggedArray[y][x];
        }
    }
}
