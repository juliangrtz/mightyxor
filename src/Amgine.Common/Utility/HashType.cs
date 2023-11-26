namespace Amgine.Common.Utility;

/// <summary>
/// Specifies the type of the hash that is to be calculated.
/// </summary>
public enum HashType
{
    /// <summary>
    /// Message-digest (128 bit)
    /// </summary>
    MD5,

    /// <summary>
    /// Secure Hash Algorithm 1 (160 bits)
    /// </summary>
    SHA1,

    /// <summary>
    /// Secure Hash Algorithm 256 (256 bits)
    /// </summary>
    SHA256
}