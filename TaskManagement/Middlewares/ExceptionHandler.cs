using System.Net;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Models;
using TaskManagement.Utils.Exceptions;

namespace TaskManagement.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(CustomException ex)
            {
                HandleCustomException(httpContext, ex);
            }
            catch (Exception ex)
            {
                 HandleExceptionAsync(httpContext, ex);
            }
        }
        private void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new GenericResponse<string>
            {
                StatusCode = context.Response.StatusCode,
                ResponseData = null,
                ErrorMessage = exception.Message
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            context.Response.WriteAsync(jsonResponse);
        }

        private void HandleCustomException(HttpContext context, CustomException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.Status;
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                ErrorName = exception.Name,
                ErrorMessage = exception.Message
            };
            var jsonResponse = JsonSerializer.Serialize(response);
            context.Response.WriteAsync(jsonResponse);
        }
    }
}
