namespace Web.Api.Extensions;

public static class ResultExtensions
{
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
