using Amgine.Common.Exceptions;
using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.Crypto.OTP;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace Amgine.UnitTests.Core.Crypto.OTP;

public class XorCalculatorTests
{
    private XorCalculator _xorCalculator = null!;
    private const int LargePlaintextSize = int.MaxValue / 8;

    [SetUp]
    public void SetUp()
    {
        _xorCalculator = new XorCalculator(xor64BitsAtATime: true);
    }

    /*
     * Trivial cases
     */

    [Test]
    public void Test_Empty_Plaintext()
    {
        // Given
        var plaintext = Array.Empty<byte>();
        var key = new byte[] { 0xCA, 0xFE };

        // When/Then
        var exception = Assert.Throws<ArgumentException>(() => _xorCalculator.Xor(plaintext, key));
        Assert.AreEqual("The input bytes may not be empty. (Parameter 'bytes')", exception?.Message);
    }

    [Test]
    public void Test_Empty_Key()
    {
        // Given
        var plaintext = new byte[] { 0xCA, 0xFE };
        var key = Array.Empty<byte>();

        // When/Then
        var exception = Assert.Throws<ArgumentException>(() => _xorCalculator.Xor(plaintext, key));
        Assert.AreEqual("The key bytes may not be empty. (Parameter 'key')", exception?.Message);
    }

    [Test]
    public void Test_Undersized_Key()
    {
        // Given
        var plaintext = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE };
        var key = new byte[] { 0xDE, 0xAD, 0xBE };

        // When/Then
        var exception = Assert.Throws<InvalidKeyException>(() => _xorCalculator.Xor(plaintext, key));
        Assert.AreEqual($"Invalid key length ({key.Length} bytes)! The key has to have at least {plaintext.Length} bytes.", exception?.Message);
    }

    [Test]
    public void Test_Equal_Plaintext_And_Key()
    {
        // Given
        var plaintext = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE };
        var key = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE };

        // When
        var result = _xorCalculator.Xor(plaintext, key);

        // Then
        // a XOR a = 0
        Assert.AreEqual(Enumerable.Repeat(0x00, plaintext.Length), result);
    }

    /*
    * Non-trivial cases
    */

    [Test]
    public void Test_Large_Plaintext()
    {
        // Given
        var keyGen = new PRNG();
        var plaintext = keyGen.GenerateKey(LargePlaintextSize);
        var key = keyGen.GenerateKey(LargePlaintextSize + LargePlaintextSize / 10);

        // When
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _xorCalculator.Xor(plaintext, key);
        stopWatch.Stop();

        // Then
        var elapsedTime = stopWatch.ElapsedMilliseconds;
        Assert.LessOrEqual(elapsedTime, 2500);
    }
}