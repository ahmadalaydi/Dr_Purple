using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Dr_Purple.Application.Utility.Exceptions;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception e)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        string message = "Internal Server Error";
        string messageId = httpContext.Response.StatusCode.ToString();
        string result = new ErrorDetails
        {
            Message = message,
            StatusCode = httpContext.Response.StatusCode,
            MessageId = messageId
        }.ToString();


        GetValidationException(httpContext, e, ref message, ref result, ref messageId);
        GetAuthException(httpContext, e, ref message, ref result, ref messageId);

        return httpContext.Response.WriteAsync(result);
    }

    private static void GetAuthException(HttpContext httpContext, Exception e, ref string message, ref string result, ref string messageId)
    {
        if (e.GetType() == typeof(AuthException))
        {
            //var exeption = (AuthException)e;
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            result = new ErrorDetails
            {
                Message = message,
                StatusCode = httpContext.Response.StatusCode,
                MessageId = messageId
            }.ToString();
        }
    }

    private static void GetValidationException(HttpContext httpContext, Exception e, ref string message, ref string result, ref string messageId)
    {
        if (e.GetType() == typeof(ValidationException))
        {
            //var exeption = (ValidationException)e;
            httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            result = new ErrorDetails
            {
                Message = message,
                StatusCode = httpContext.Response.StatusCode,
                MessageId = messageId//exeption.Errors.FirstOrDefault()!.ErrorCode
            }.ToString();
        }
    }
}
