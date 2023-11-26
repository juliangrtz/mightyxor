using Amgine.Common.Logging;
using Amgine.Common.Utility;
using Amgine.Core.Crypto.KeyGenerators;
using NUnit.Framework;
using System;

namespace Amgine.UnitTests.Core.Crypto.KeyGenerators
{
    public class KeyGeneratorTests
    {
        // Every RNG has to have a Shannon entropy of 7.8.
        private const double LowerEntropyBound = 7.5d;

        private const int MaximumByteEntropy = 8; // see https://stats.stackexchange.com/a/49174
        private const double MaximumAllowedDelta = 0.15d;

        private byte[] _keyBuffer = null!;
        private IKeyGenerator _keyGenerator = null!;

        [Test]
        [TestCase(2048)]
        [TestCase(8192)]
        [TestCase(131072)]
        public void Test_PRNG_Entropy(int keySize)
        {
            // Given
            _keyGenerator = new PRNG();

            // When
            _keyBuffer = _keyGenerator.GenerateKey(keySize);

            // Then
            TestEntropy(_keyGenerator.GetType(), _keyBuffer);
        }

        [Test]
        [TestCase(2048)]
        [TestCase(8192)]
        [TestCase(131072)]
        public void Test_Non_Arithmetic_PRNG_Entropy(int keySize)
        {
            // Given
            _keyGenerator = new NonArithmeticPRNG();

            // When
            _keyBuffer = _keyGenerator.GenerateKey(keySize);

            // Then
            TestEntropy(_keyGenerator.GetType(), _keyBuffer);
        }

        [Test]
        [TestCase(2048)]
        [TestCase(8192)]
        [TestCase(131072)]
        public void Test_PCG_Entropy(int keySize)
        {
            // Given
            _keyGenerator = new PCG();

            // When
            _keyBuffer = _keyGenerator.GenerateKey(keySize);

            // Then
            TestEntropy(_keyGenerator.GetType(), _keyBuffer);
        }

        private static void TestEntropy(Type keyGeneratorType, byte[] keyBuffer)
        {
            var entropy = EntropyUtil.ShannonEntropy(keyBuffer);
            Logger.Log($"{keyGeneratorType} has a Shannon entropy of {entropy}.");
            Assert.GreaterOrEqual(entropy, LowerEntropyBound);
            Assert.LessOrEqual(MaximumByteEntropy - entropy, MaximumAllowedDelta);
        }
    }
}