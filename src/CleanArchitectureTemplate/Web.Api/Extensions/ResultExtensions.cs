namespace Web.Api.Extensions;

/// <summary>
/// Extension methods for <see cref="Result"/> and <see cref="Result{TValue}"/> primitives.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts <see cref="Result"/> objects to <see cref="ObjectResult"/> containing <see cref="ProblemDetails"/>.
    /// </summary>
    /// <param name="result"><see cref="Result"/> object.</param>
    /// <returns><see cref="ObjectResult"/> object.</returns>
    /// <exception cref="InvalidOperationException">Throws if the passed <paramref name="result"/> is a success.</exception>
    public static ObjectResult AsProblem(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException(
                "Unable to convert success result to problem details.");

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Client Error",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Extensions = new Dictionary<string, object?>
            {
                { "errors", result.Errors },
            },
        };

        return new ObjectResult(problem);
    }
}
