﻿using BenchmarkDotNet.Running;

namespace MightyXOR.Benchmarks
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}