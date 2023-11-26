using Amgine.Core.Libraries.naPRNGs;

namespace Amgine.Core.Crypto.KeyGenerators;

/// <summary>
/// A non-arithmetic pseudorandom number generator by Torben Aberspach,
/// see <see href="http://www.naRND.de/"></see>
/// </summary>
public class NonArithmeticPRNG : IKeyGenerator
{
    /// <inheritdoc />
    public byte[] GenerateKey(long length)
    {
        var randomPermutation = naTools.GetRandomPermutation((int)length);
        return naTools.ToByteArray(randomPermutation);
    }

    /// <inheritdoc />
    public void GenerateKeyToFile(long length, string filePath)
        => File.WriteAllBytes(filePath, GenerateKey(length));
}