﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace eHospitalServer.Presentation.Middlewares;
public sealed class ExceptionMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";

        if (exception.GetType() == typeof(ValidationException))
        {
            httpContext.Response.StatusCode = 409;
        }

        var responseObj = new
        {
            ErrorMessage = exception.Message,
        };

        var responseString = JsonSerializer.Serialize(responseObj);

        await httpContext.Response.WriteAsync(responseString);

        return true;
    }
}
