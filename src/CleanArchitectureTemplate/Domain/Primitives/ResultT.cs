﻿namespace Domain.Primitives;

/// <summary>
/// Generic class representing a result of an operation.
/// </summary>
public class Result<TValue> : Result
{
    /// <summary>
    /// Resulted value. Might be null.
    /// </summary>
    public TValue? Value { get; private set; }

    public bool HasValue { get; private set; }

    internal Result()
    {
        IsSuccess = true;
        Value = default;
        HasValue = false;
    }

    internal Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        HasValue = false;
    }

    internal Result(Error error)
    {
        IsSuccess = false;
        Value = default;
        HasValue = false;
        Errors.Add(error);
    }

    internal Result(List<Error> errors)
    {
        IsSuccess = false;
        Value = default;
        HasValue = false;
        Errors = errors;
    }

    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(Error error) => new(error);
    public static implicit operator Result<TValue>(List<Error> errors) => new(errors);

    public void Deconstruct(out bool isSuccess, out TValue? value, out List<Error> errors)
    {
        isSuccess = IsSuccess;
        value = Value;
        errors = Errors;
    }
}