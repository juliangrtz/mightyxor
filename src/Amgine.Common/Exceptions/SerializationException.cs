namespace Amgine.Common.Exceptions;

/// <summary>
/// Is thrown when a (de)serialization failed.
/// </summary>
public class SerializationException : Exception
{
    public SerializationException()
    {
    }

    public SerializationException(string message) : base(message)
    {
    }

    public SerializationException(string message, Exception inner) : base(message, inner)
    {
    }
}