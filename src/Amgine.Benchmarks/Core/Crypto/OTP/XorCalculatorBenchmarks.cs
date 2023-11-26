using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.Crypto.OTP;
using BenchmarkDotNet.Attributes;

namespace Amgine.Benchmarks.Core.Crypto.OTP
{
    public class XorCalculatorBenchmarks
    {
        private readonly XorCalculator _xorCalculator8;
        private readonly XorCalculator _xorCalculator64;
        private const long DataLength = 100 * 1024 * 1024; // 100 MB
        private readonly byte[] _data, _key;


        public XorCalculatorBenchmarks()
        {
            _xorCalculator8 = new XorCalculator(xor64BitsAtATime: false);
            _xorCalculator64 = new XorCalculator(xor64BitsAtATime: true);
            var prng = new PRNG();
            _data = prng.GenerateKey(DataLength);
            _key = prng.GenerateKey(DataLength);
        }

        [Benchmark]
        public void Xor8()
        {
            var result = _xorCalculator8.Xor(_data, _key);
            result.ToList().ForEach(b =>
            {
                // Pretending to do something with the result...
                b ^= 0xAF;
            });
        }

        [Benchmark]
        public void Xor64()
        {
            var result = _xorCalculator64.Xor(_data, _key);
            result.ToList().ForEach(b =>
            {
                // Pretending to do something with the result...
                b ^= 0xAF;
            });
        }
    }
}
