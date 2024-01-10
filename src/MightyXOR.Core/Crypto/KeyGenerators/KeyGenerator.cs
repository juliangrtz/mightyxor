namespace MightyXOR.Core.Crypto.KeyGenerators;

/// <summary>
/// Specifies types of key generators.
/// </summary>
public enum KeyGenerator
{
    /// <summary>
    /// A pseudorandom number generator
    /// </summary>
    PRNG,

    /// <summary>
    /// A non-arithmetic pseudorandom number generator
    /// </summary>
    NonArithmeticPRNG,

    /// <summary>
    /// Permuted congruential generator combining RNGs.
    /// Described in <see href="https://www.pcg-random.org/pdf/hmc-cs-2014-0905.pdf">this paper</see>.
    /// </summary>
    PCG
}