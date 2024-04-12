namespace Domain.Primitives;

/// <summary>
/// Class representing an error. Consists of a message and an error code.
/// </summary>
public class Error
{
    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// Error code.
    /// </summary>
    public string Code { get; private set; }

    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }

    public Error(string message)
    {
        Message = message;
        Code = string.Empty;
    }
}