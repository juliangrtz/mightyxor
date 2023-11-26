namespace Amgine.Common.Logging;

/// <summary>
/// Used to distinguish different log messages.
/// </summary>
public enum LogType
{
    /// <summary>
    /// Represents general information.
    /// </summary>
    Info,

    /// <summary>
    /// Represents warnings. Unlike the <see cref="Error"></see> value, this should not be used for exceptions.
    /// </summary>
    Warning,

    /// <summary>
    /// Primarily used for exceptions and other severe errors.
    /// </summary>
    Error,

    /// <summary>
    /// Used for debugging purposes.
    /// </summary>
    Debug
}