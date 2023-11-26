using BenchmarkDotNet.Running;

namespace Amgine.Benchmarks
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}