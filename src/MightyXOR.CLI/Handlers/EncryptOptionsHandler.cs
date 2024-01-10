using MightyXOR.CLI.Options;
using MightyXOR.Common.Logging;
using MightyXOR.Core.Crypto.OTP;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.CLI.Handlers;

internal class EncryptOptionsHandler : IOptionHandler
{
    private readonly EncryptOptions _options;

    public EncryptOptionsHandler(EncryptOptions keygenOptions)
    {
        _options = keygenOptions;
    }

    private MightyXorSettings BuildSettings()
    {
        return new MightyXorSettings
        {
            UseFileHeader = _options.GenerateHeader ?? true,
            OutputDirectory = _options.OutputDirectory,
            SetCiphertextReadOnly = _options.SetCiphertextReadOnly,
        };
    }

    private bool CheckParameters()
    {
        if (!File.Exists(_options.PlaintextPath))
        {
            Log($"{_options.PlaintextPath} does not point to an existing file.", LogType.Error);
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

    private void Encrypt()
    {
        var oneTimePad = new OneTimePad(BuildSettings(), _options.KeyPath);
        oneTimePad.EncryptFile(_options.PlaintextPath);
    }

    public void Handle()
    {
        if (!CheckParameters())
            Environment.Exit(-1);

        SetLogLevel();
        Encrypt();
    }
}