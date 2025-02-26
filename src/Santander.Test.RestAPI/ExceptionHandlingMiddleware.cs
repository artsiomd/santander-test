using Microsoft.AspNetCore.Mvc;

namespace Santander.Test.RestAPI;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BadHttpRequestException ex)
        {
            _logger.LogError(ex, "Bad Request {Message}", ex.Message);
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(CreateProblemDetails(
                StatusCodes.Status400BadRequest,
                "BAD_REQUEST",
                ex.Message,
                "https://docs.myapi.com/errors#bad-request"
            ));
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Internal Server Error {Message}", ex.Message);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(CreateProblemDetails(
                StatusCodes.Status500InternalServerError,
                "INTERNAL_SERVER_ERROR",
                "An unexpected error occurred. Please try again later.",
                "https://docs.myapi.com/errors#internal-server-error"
            ));
        }
    }

    private static ProblemDetails CreateProblemDetails(int status, string errorCode, string message, string docsUrl)
    {
        return new ProblemDetails
        {
            Status = status,
            Title = errorCode,
            Detail = message,
            Extensions = { { "docsUrl", docsUrl } }
        };
    }
}
