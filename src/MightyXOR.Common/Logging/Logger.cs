using log4net;
using log4net.Config;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MightyXOR.Common.Logging;

/// <summary>
/// Serves as a common log4net logging class.
/// </summary>
public static class Logger
{
    private static bool _isInitialized;
    public static LogLevel LogLevel { get; set; } = LogLevel.Normal;

    /// <summary>
    /// Initializes the logger.
    /// Requires a configured <see href="log4net.config">log4net.config file</see>.
    /// </summary>
    public static void Initialize(string configFileLocation = "log4net.config")
    {
        if (!_isInitialized)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(configFileLocation));
            _isInitialized = true;
        }
    }

    /// <summary>
    /// Peforms a shutdown on a previously initialized logger.
    /// </summary>
    public static void Shutdown()
    {
        if (_isInitialized)
        {
            LogManager.Shutdown();
        }
    }

    /// <summary>
    /// Logs a given message to the initialized logger.
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="logType">The logging type</param>
    /// <param name="minimumLogLevel">The minimum logging level</param>
    /// <exception cref="ArgumentException"></exception>

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Log(string message, LogType logType = LogType.Info, LogLevel minimumLogLevel = LogLevel.Normal)
    {
        if (string.IsNullOrWhiteSpace(message))
            return;

        var logger = LogManager.GetLogger(Assembly.GetCallingAssembly().GetName().Name);

        if (LogLevel < minimumLogLevel) return;

        switch (logType)
        {
            case LogType.Info:
                logger.Info(message);
                break;

            case LogType.Warning:
                logger.Warn(message);
                break;

            case LogType.Error:
                logger.Error(message);
                break;

            case LogType.Debug:
                logger.Debug(message);
                break;

            default:
                throw new ArgumentException($"{logType} is an unknown log type!");
        }
    }

    public static void Log(string message, LogLevel logLevel, LogType logType = LogType.Info)
        => Log(message, logType, logLevel);
}