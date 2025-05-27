using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace WebApi.Handler
{
    public class GlobalExceptionHandler(IHostEnvironment env , ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private const string UnhandledExceptionMsg = "An unhandled exception has occurred while executing the request.";
        private static readonly JsonSerializerOptions serializerOptions = new(JsonSerializerDefaults.Web)
        {
            Converters = {new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)},
        };
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not BaseException)
            {
                // Log the exception
                return false; // Return false to let other handlers process the exception
            }
            logger.LogError(exception.Message);
            var problemDetails = CreateProblemDetails(httpContext, exception);
            var json = ToJson(problemDetails);

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = problemDetails.Status!.Value;
            await httpContext.Response.WriteAsync(json, cancellationToken);
            return true;
        }

        // in C# 10, the `in` keyword is used to indicate that the parameter is passed by reference and is read-only.
        //  เราแค่อ่าไม่แก้ไขค่าใน `httpContext` และ `exception` เท่านั้นเพราะฉะนั้นใช้ `in` เพื่อประสิทธิภาพที่ดีขึ้นไม่ต้อง copy ค่า
        private ProblemDetails CreateProblemDetails(in HttpContext context , in Exception exception)
        {
            var errorCode =  exception.GetType();
            var statusCode = context.Response.StatusCode;
            var resonPhrase =ReasonPhrases.GetReasonPhrase(statusCode);
            if(string.IsNullOrEmpty(resonPhrase))
            {
                resonPhrase = UnhandledExceptionMsg;
            }
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = resonPhrase,
                Extensions = {
                    [nameof(errorCode)] = errorCode.Name,   
                }
            };

            if(!env.IsDevelopment())
            {
                return problemDetails;
            }
            problemDetails.Detail = exception.ToString();
            problemDetails.Extensions["traceId"] = Activity.Current?.Id;
            problemDetails.Extensions["requestId"] = context.TraceIdentifier;
            problemDetails.Extensions["data"] = exception.Data;

            return problemDetails;
        }
        private string ToJson(in ProblemDetails problemDetails)
        {
            try
            {
                return JsonSerializer.Serialize(problemDetails , serializerOptions);
            }
            catch (Exception ex)
            {
                const string msg = "An exception has occurred while serializing error to JSON";
                logger.LogError(ex, msg);
            }
            return string.Empty;
        }
    }
}
/*
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

*/
