﻿using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace Web.Api.Services;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.TraceId.ToString()
            ?? httpContext.TraceIdentifier;

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Unhandled server error occured.",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Extensions = new Dictionary<string, object?>
            {
                { "traceId", traceId },
            },
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
