using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetial = new ProblemDetails
            {
                Title = "An error occurred",
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message
            };
            httpContext.Response.StatusCode = problemDetial.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetial,cancellationToken);
            return true;
        }
    }
}