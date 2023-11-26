namespace Amgine.Common.Exceptions;

/// <summary>
/// Is thrown when a file causes problems, e.g. when it is already used by another process.
/// </summary>
public class InvalidFileException : Exception
{
    public InvalidFileException()
    {
    }

    public InvalidFileException(string message) : base(message)
    {
    }

    public InvalidFileException(string message, Exception inner) : base(message, inner)
    {
    }
}