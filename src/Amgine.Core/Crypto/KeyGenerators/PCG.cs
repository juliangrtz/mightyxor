using Pcg;

namespace Amgine.Core.Crypto.KeyGenerators;

/// <summary>
/// Key generator based off the PCG family for good random number generation
/// (see <see href="https://www.pcg-random.org/pdf/hmc-cs-2014-0905.pdf"></see>)
/// </summary>
public class PCG : IKeyGenerator
{
    /// <inheritdoc />
    public byte[] GenerateKey(long length)
    {
        var key = new byte[length];
        var rng = new PcgRandom();
        rng.NextBytes(key);
        return key;
    }

    /// <inheritdoc />
    public void GenerateKeyToFile(long length, string filePath)
        => File.WriteAllBytes(filePath, GenerateKey(length));
}