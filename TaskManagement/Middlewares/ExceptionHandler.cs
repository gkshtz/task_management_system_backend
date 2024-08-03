using System.Net;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Models;

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
    }
}
