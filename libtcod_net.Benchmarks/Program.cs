using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace libtcod_net.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
