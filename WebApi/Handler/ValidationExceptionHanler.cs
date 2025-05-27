using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handler;


public class ValidationExceptionHanler : IExceptionHandler
{
    // Custom exception handler for validation errors
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is not CustomValidation validationException)
        {
            return false;
        }
        var problemDetails = new ProblemDetails
        {
            Title = validationException.Message,
            Status = StatusCodes.Status400BadRequest,
            Detail = validationException.Message,
            Type = exception.GetType().Name,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
            Extensions = {["errors"] = validationException.Errors}
            
        };
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(problemDetails,cancellationToken);
        return true;
    }
}