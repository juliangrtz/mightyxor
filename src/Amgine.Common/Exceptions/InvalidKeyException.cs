namespace Amgine.Common.Exceptions;

/// <summary>
/// Is thrown when a key causes problems, e.g. when its length is invalid.
/// </summary>
public class InvalidKeyException : Exception
{
    public InvalidKeyException()
    {
    }

    public InvalidKeyException(string message) : base(message)
    {
    }

    public InvalidKeyException(string message, Exception inner) : base(message, inner)
    {
    }
}