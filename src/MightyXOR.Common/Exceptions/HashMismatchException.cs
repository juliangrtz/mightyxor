namespace MightyXOR.Common.Exceptions;

/// <summary>
/// Is thrown when a hash mismatch occurs.
/// </summary>
public class HashMismatchException : Exception
{
    public HashMismatchException()
    {
    }

    public HashMismatchException(string message) : base(message)
    {
    }

    public HashMismatchException(string message, Exception inner) : base(message, inner)
    {
    }
}