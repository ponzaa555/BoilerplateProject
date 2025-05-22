using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorResponse error = new();
            if (exception is BaseException baseException)
            {
                
                   error.StatusCode = baseException.StatusCode;
                   error. Message =  baseException.Message;
                    error.ErrorAt = baseException.ErrorAt;
            }else
            {
                error.StatusCode = 000;
                error. Message =  "Un expect error";
                error.ErrorAt = " Idon't knows";
            }
            httpContext.Response.StatusCode = error.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(error,cancellationToken);
            return true;
        }


    }
}