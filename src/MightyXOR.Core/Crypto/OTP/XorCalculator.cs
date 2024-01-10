using MightyXOR.Common.Exceptions;
using MightyXOR.Common.Logging;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.Core.Crypto.OTP;

/// <summary>
/// Helps with the XOR operation.
/// </summary>
public class XorCalculator
{
    private readonly bool _xor64BitsAtATime;

    public XorCalculator(bool xor64BitsAtATime)
    {
        _xor64BitsAtATime = xor64BitsAtATime;
    }

    private static void CheckLengths(byte[] bytes, byte[] key)
    {
        if (!bytes.Any())
            throw new ArgumentException("The input bytes may not be empty.", nameof(bytes));

        if (!key.Any())
            throw new ArgumentException("The key bytes may not be empty.", nameof(key));

        if (key.Length < bytes.Length)
        {
            throw new InvalidKeyException(
                $"Invalid key length ({key.Length} bytes)! The key has to have at least {bytes.Length} bytes.");
        }
    }

    /// <summary>
    /// Serves both as encryption and decryption method for the <see cref="OneTimePad"/>.
    /// This is allowed since XOR is an <see href="https://en.wikipedia.org/wiki/Involution_(mathematics)">involutory function</see>.
    /// </summary>
    /// <param name="bytes">The bytes to en- or decrypt</param>
    /// <param name="key">The key (aka. pad)</param>
    /// <returns> The en-/decrypted bytes</returns>
    /// <exception cref="InvalidKeyException"></exception>
    public byte[] Xor(byte[] bytes, byte[] key)
    {
        CheckLengths(bytes, key);

        if (_xor64BitsAtATime)
            XOr64(bytes, key);
        else
            XOr8(bytes, key);

        Log($"{bytes.Length} bytes XORed.", LogType.Debug, LogLevel.Detailed);
        return bytes;
    }

    /// <summary>
    /// XORs two byte arrays with 8-bits-at-a-time (one byte).
    /// </summary>
    private static void XOr8(byte[] array1, byte[] array2)
    {
        for (var i = 0; i < array1.Length; i++)
            array1[i] ^= array2[i];
    }

    /// <summary>
    /// XORs two byte arrays with 64-bits-at-a-time (8 bytes).
    /// Adapted from <see href="https://stackoverflow.com/a/50250226/4350677"></see>.
    /// </summary>
    private static unsafe void XOr64(byte[] array1, byte[] array2)
    {
        // First XOR as many 64-bit blocks as possible, for the sake of speed
        var chunks = array1.Length / 8;

        fixed (byte* byteA = array1)
        fixed (byte* byteB = array2)
        {
            var ppA = (long*)byteA;
            var ppB = (long*)byteB;

            for (var p = 0; p < chunks; p++)
            {
                *ppA ^= *ppB;
                ppA++;
                ppB++;
            }
        }

        // Now cover any remaining bytes one byte at a time.
        for (var index = chunks * 8; index < array1.Length; index++)
            array1[index] ^= array2[index];
    }
}