using Amgine.Common.Logging;

namespace Amgine.CLI.Options;

[Verb("encrypt", HelpText = "Encrypt a plaintext via one-time pad.")]
internal class EncryptOptions
{
    [Value(index: 0,
        HelpText = "Input path of the plaintext file to encrypt. Required argument.",
        Required = true)]
    public string PlaintextPath { get; init; } = string.Empty;

    [Option('k', "key",
        HelpText = "Path of the key. Required argument.",
        Required = true)]
    public string KeyPath { get; init; } = string.Empty;

    [Option('v', "verbosity",
        HelpText = "The level of detail for the logger. " +
                   "Available levels: Quiet (0), Minimal (1), Normal (2), Detailed (3), Diagnostic (4)",
        Default = LogLevel.Diagnostic)]
    public LogLevel LogLevel { get; set; }

    [Option('h', "generate-header",
        HelpText = "If enabled, the ciphertext contains a header with metadata about the plaintext file, " +
                   "e.g. the file name, access date etc.",
        Default = true)]
    public bool? GenerateHeader { get; set; }

    [Option('r', "read-only",
        HelpText = "If enabled, the ciphertext is set read-only after the encryption to make tampering more difficult.",
        Default = false)]
    public bool SetCiphertextReadOnly { get; set; }

    [Option('o', "output-dir",
        HelpText = "Optional output directory for the ciphertext file. " +
                   "If no directory is provided, the current working directory is used.")]
    public string OutputDirectory { get; init; } = Directory.GetCurrentDirectory();
}