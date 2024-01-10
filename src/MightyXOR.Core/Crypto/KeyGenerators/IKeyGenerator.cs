namespace MightyXOR.Core.Crypto.KeyGenerators;

/// <summary>
/// Serves as an interface for various key generators.
/// </summary>
public interface IKeyGenerator
{
    /// <summary>
    /// Generates a (cryptographically secure) key that can be used for en- and decryption.
    /// </summary>
    /// <param name="length">Length of the key in bytes</param>
    byte[] GenerateKey(long length);

    /// <summary>
    /// Like <see cref="GenerateKey"/>, but the key is exported to a file.
    /// </summary>
    /// <param name="length">Length of the key in bytes</param>
    /// <param name="filePath">Output path</param>
    void GenerateKeyToFile(long length, string filePath);

    /// <summary>
    /// Obtains an IKeyGenerator from the respective enum type.
    /// </summary>
    /// <param name="keyGenerator">The key generator as enum</param>
    /// <returns>Its respective type</returns>
    public static IKeyGenerator FromEnum(KeyGenerator keyGenerator)
    {
        IKeyGenerator keyGen = keyGenerator switch
        {
            KeyGenerator.PRNG => new PRNG(),
            KeyGenerator.NonArithmeticPRNG => new NonArithmeticPRNG(),
            KeyGenerator.PCG => new PCG(),
            _ => new PRNG()
        };

        return keyGen;
    }
}