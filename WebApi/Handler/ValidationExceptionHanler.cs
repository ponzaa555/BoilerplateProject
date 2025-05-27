using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Handler;


public class ValidationExceptionHanler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}