namespace Domain.Primitives;

/// <summary>
/// Base abstract class representing a result of an operation.
/// </summary>
public abstract class Result
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => IsSuccess is not true;

    /// <summary>
    /// List of errors.
    /// </summary>
    public List<Error> Errors { get; protected set; } = [];

    protected Result() { }

    /// <returns>Empty success result.</returns>
    public static Result<TValue> Ok<TValue>() => new();

    /// <returns>Success result with a value.</returns>
    public static Result<TValue> Ok<TValue>(TValue value) => new(value);

    /// <returns>Failure result with an error. Error code will be empty string.</returns>
    public static Result<TValue> Fail<TValue>(string message) => new(new Error(message));

    /// <returns>Failure result with an error.</returns>
    public static Result<TValue> Fail<TValue>(string message, string code) => new(new Error(message, code));

    /// <returns>Failure result with an error.</returns>
    public static Result<TValue> Fail<TValue>(Error error) => new(error);

    /// <returns>Failure result with a list of errors.</returns>
    public static Result<TValue> Fail<TValue>(List<Error> errors) => new(errors);
}
