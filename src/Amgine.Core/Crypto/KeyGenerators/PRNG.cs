using System.Security.Cryptography;

namespace Amgine.Core.Crypto.KeyGenerators;

/// <summary>
/// Pseudorandom number generator working with C#'s <see cref="RandomNumberGenerator"/> class.
/// </summary>
public class PRNG : IKeyGenerator
{
    /// <inheritdoc />
    public byte[] GenerateKey(long length)
    {
        var key = new byte[length];
        var prng = RandomNumberGenerator.Create();
        prng.GetNonZeroBytes(key);
        return key;
    }

    /// <inheritdoc />
    public void GenerateKeyToFile(long length, string filePath)
        => File.WriteAllBytes(filePath, GenerateKey(length));
}