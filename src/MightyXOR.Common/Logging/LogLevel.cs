namespace MightyXOR.Common.Logging;

/// <summary>
/// Used to distinguish different verbosity levels from "quiet" to "diagnostic".
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Effectively disables the logger. No message at all is displayed.
    /// </summary>
    Quiet = 0,

    /// <summary>
    /// Lowest level of detail. Merely crucial information is logged.
    /// </summary>
    Minimal = 1,

    /// <summary>
    /// Default level of detail, as defined in the <see cref="Logger.LogLevel"/>.
    /// </summary>
    Normal = 2,

    /// <summary>
    /// Provides in-depth information about various processes.
    /// </summary>
    Detailed = 3,

    /// <summary>
    /// Highest level of detail. Only used for extensive analysis, e.g. debugging.
    /// </summary>
    Diagnostic = 4
}