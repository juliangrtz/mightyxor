using Amgine.CLI.Options;
using Amgine.Common.Logging;
using Amgine.Core.Crypto.KeyGenerators;
using LogLevel = Amgine.Common.Logging.LogLevel;

namespace Amgine.CLI.Handlers;

internal class KeygenOptionsHandler : IOptionHandler
{
    private readonly KeygenOptions _options;

    public KeygenOptionsHandler(KeygenOptions keygenOptions)
    {
        _options = keygenOptions;
    }

    private bool CheckParameters()
    {
        if (_options.Length <= 0)
        {
            Log($"The length {_options.Length} is invalid. It must be at least 1.", LogType.Error);
            return false;
        }

        if (Directory.Exists(_options.OutputPath))
        {
            Log($"{_options.OutputPath} is a directory. " +
                "Please provide a complete path, including a filename at the end.", LogType.Error);
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

    private void GenerateKey()
    {
        Log($"Key generator: {_options.KeyGenerator}");
        IKeyGenerator keyGenerator = _options.KeyGenerator switch
        {
            KeyGenerator.PRNG => new PRNG(),
            KeyGenerator.NonArithmeticPRNG => new NonArithmeticPRNG(),
            KeyGenerator.PCG => new PCG(),
            _ => new PRNG()
        };

        var path = string.IsNullOrWhiteSpace(_options.OutputPath)
            ? Environment.CurrentDirectory + "\\key.bin"
            : _options.OutputPath;

        var file = new FileInfo(path);
        file.Directory?.Create();
        Log($"Output path: {path}");

        try
        {
            keyGenerator.GenerateKeyToFile(_options.Length, path);
            Log("Successfully generated the key.");
        }
        catch (Exception ex)
        {
            Log($"Key generation failed: {ex}", LogType.Error);
        }
    }

    public void Handle()
    {
        if (!CheckParameters())
            Environment.Exit(-1);

        SetLogLevel();
        GenerateKey();
    }
}