namespace Amgine.Core.Models;

/// <summary>
/// Provides options for the en- and decryption of files.
/// </summary>
[Serializable]
public class AmgineSettings
{
    // ToDo: Distinguish between EncryptSettings and DecryptSettings

    /// <summary>
    /// The output directory for resulting plain-/ciphertexts.
    /// It is the current working directory of the application by default.
    /// </summary>
    public string OutputDirectory { get; set; } = Directory.GetCurrentDirectory();

    /// <summary>
    /// Determines if Amgine should include the file header
    /// specified in the class <see cref="AmgineFileHeader"/>
    /// containing metadata of a file that is being en- or decrypted.
    /// <code>Default: true</code>
    /// </summary>
    public bool UseFileHeader { get; set; } = true;

    /// <summary>
    /// Specifies if the original file containing the plaintext/ciphertext
    /// is supposed to be overridden during its encryption/decryption.
    /// <code>Default: false</code>
    /// </summary>
    public bool OverrideFile { get; set; } = false;

    /// <summary>
    /// If enabled, the ciphertext file is set to read-only
    /// after a successful encryption. Encryption-specific setting.
    /// <code>Default: false</code>
    /// </summary>
    public bool SetCiphertextReadOnly { get; set; } = false;

    /// <summary>
    /// <see cref="UseFileHeader"/> must be true for this to have an effect.
    /// If it is, the MD5 hash <see cref="AmgineFileHeader.Md5Hash">specified in the header</see>
    /// is compared with the actual hash of the <see cref="AmgineFile.Content">file content</see>.
    /// This way, alterations to the ciphertext may be detected.
    /// Decryption-specific setting.
    /// <code>Default: true</code>
    /// </summary>
    public bool CompareHashesInHeader { get; set; } = true;

    /// <summary>
    /// If enabled, a used key is deleted after its usage in a decryption.
    /// See <see cref="TimesToOverrideDeletedFiles"/>.
    /// Decryption-specific setting.
    ///<code>Default: false</code>
    /// </summary>
    public bool DeleteKeyAfterDecryption { get; set; } = false;

    /// <summary>
    /// The number of override operations for a file
    /// that is supposed to be deleted securely.
    ///<code>Default: 10</code>
    /// </summary>
    public int TimesToOverrideDeletedFiles { get; set; } = 10;
}