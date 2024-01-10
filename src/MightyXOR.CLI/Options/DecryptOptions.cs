using MightyXOR.Common.Logging;

namespace MightyXOR.CLI.Options;

[Verb("decrypt", HelpText = "Decrypt a ciphertext via one-time pad.")]
internal class DecryptOptions
{
    [Value(index: 0,
        HelpText = "Input path of the ciphertext file to decrypt.",
        Required = true)]
    public string CiphertextPath { get; init; } = string.Empty;

    [Option('k', "key",
        HelpText = "Path of the key.",
        Required = true)]
    public string KeyPath { get; init; } = string.Empty;

    [Option('d', "delete-key",
        HelpText = "Deletes the key after a successful decryption if enabled.",
        Default = false)]
    public bool DeleteKeyAfterDecryption { get; init; }

    [Option('h', "compare-hashes",
        HelpText = "Compares the hash given in the header with the actual hash of the plaintext.",
        Default = true)]
    public bool CompareHashes { get; init; }

    [Option('v', "verbosity",
        HelpText = "The level of detail for the logger. " +
                   "Available levels: Quiet (0), Minimal (1), Normal (2), Detailed (3), Diagnostic (4)",
        Default = LogLevel.Diagnostic)]
    public LogLevel LogLevel { get; set; }

    [Option('o', "output-directory",
        HelpText = "Optional output directory of the ciphertext file. " +
                   "If no directory is provided, the current working directory is used.")]
    public string OutputDirectory { get; init; } = Directory.GetCurrentDirectory();
}