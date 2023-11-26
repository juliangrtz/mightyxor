using Amgine.Common.Logging;
using Amgine.Core.Crypto.KeyGenerators;

namespace Amgine.CLI.Options;

[Verb("keygen", HelpText = "Generate cryptographically secure keys for en- and decryption.")]
internal class KeygenOptions
{
    [Value(0,
        HelpText = "Length of the key in bytes (max: 2147483647).",
        Required = true)]
    public int Length { get; set; }

    [Option('p', "path",
        HelpText = "Output path of the key. If no path is provided, the working directory with the file name \"key.bin\" is used.")]
    public string OutputPath { get; init; } = Directory.GetCurrentDirectory() + "\\key.bin";

    [Option('r', "rng",
        HelpText = "The random number generator. By default, a non-arithmetic PRNG is used.",
        Default = KeyGenerator.NonArithmeticPRNG)]
    public KeyGenerator KeyGenerator { get; set; }

    [Option('v', "verbosity",
        HelpText = "The level of detail for the logger. " +
                   "Available levels: Quiet (0), Minimal (1), Normal (2), Detailed (3), Diagnostic (4)",
        Default = LogLevel.Normal)]
    public LogLevel LogLevel { get; set; }

    public override string ToString()
    {
        return $"{nameof(Length)}: {Length}, " +
               $"{nameof(KeyGenerator)}: {KeyGenerator}, " +
               $"{nameof(OutputPath)}: {OutputPath}, " +
               $"{nameof(LogLevel)}: {LogLevel}";
    }
}