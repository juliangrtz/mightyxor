using MightyXOR.CLI.Options;
using MightyXOR.Common.Logging;
using MightyXOR.Core.Crypto.OTP;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.CLI.Handlers;

internal class DecryptOptionsHandler : IOptionHandler
{
    private readonly DecryptOptions _options;

    public DecryptOptionsHandler(DecryptOptions keygenOptions)
    {
        _options = keygenOptions;
    }

    private bool CheckParameters()
    {
        if (!File.Exists(_options.CiphertextPath))
        {
            Log($"{_options.CiphertextPath} does not point to an existing file.", LogType.Error);
            return false;
        }

        if (!File.Exists(_options.KeyPath))
        {
            Log($"{_options.KeyPath} does not point to an existing key.", LogType.Error);
            return false;
        }

        if (File.Exists(_options.OutputDirectory))
        {
            Log($"{_options.OutputDirectory} is a file. Please provide a directory only.", LogType.Error);
            return false;
        }

        return true;
    }

    private MightyXorSettings BuildSettings()
    {
        return new MightyXorSettings
        {
            DeleteKeyAfterDecryption = _options.DeleteKeyAfterDecryption,
            OutputDirectory = _options.OutputDirectory,
            CompareHashesInHeader = _options.CompareHashes
        };
    }

    private void SetLogLevel()
    {
        // Handle given log level
        Logger.LogLevel = _options.LogLevel;

        if (_options.LogLevel == LogLevel.Quiet)
        {
            Logger.Shutdown();
        }
        else if (_options.LogLevel >= LogLevel.Detailed)
        {
            Log($"Log level: {_options.LogLevel}", LogType.Debug);
        }
    }

    private void Decrypt()
    {
        var oneTimePad = new OneTimePad(BuildSettings(), _options.KeyPath);
        oneTimePad.DecryptFile(_options.CiphertextPath);
    }

    public void Handle()
    {
        if (!CheckParameters())
            Environment.Exit(-1);

        SetLogLevel();
        Decrypt();
    }
}