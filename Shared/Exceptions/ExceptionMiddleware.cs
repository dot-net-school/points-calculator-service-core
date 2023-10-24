using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Shared.Exceptions;

//TODO using Microsoft.AspNetCore.Http is deprecated, please find some thing for replacement
internal sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    //TODO Add logger too in here
    
    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (DbUpdateConcurrencyException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //TODO Remove Magic Words in here to or place it in Resource file
            var result = _env.IsDevelopment()
                ? OperationResult<int>.Failed($"UpdateConcurrencyException: \n{e.Message}\n{e.StackTrace}", HttpStatusCode.InternalServerError)
                : OperationResult<int>.Failed(Resource.ServerError, HttpStatusCode.InternalServerError);
            var json = JsonSerializer.Serialize(result);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
        catch (DbUpdateException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //TODO Remove Magic Words in here to or place it in Resource file
            var result = _env.IsDevelopment()
                ? OperationResult<int>.Failed($"UpdateException: \n{e.Message}\n{e.StackTrace}", HttpStatusCode.InternalServerError)
                : OperationResult<int>.Failed(Resource.ServerError, HttpStatusCode.InternalServerError);
            var json = JsonSerializer.Serialize(result);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //TODO Remove Magic Words in here to or place it in Resource file
            var result = _env.IsDevelopment()
                ? OperationResult<int>.Failed($"{e.Message}\n{e.StackTrace}", HttpStatusCode.InternalServerError)
                : OperationResult<int>.Failed(Resource.ServerError, HttpStatusCode.InternalServerError);
            var json = JsonSerializer.Serialize(result);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}