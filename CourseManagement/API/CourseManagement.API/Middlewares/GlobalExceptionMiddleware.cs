using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CourseManagement.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleUnknownException(context, error);
            }

      
        }
        private static async Task HandleUnknownException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    title = "Unknown internal exception.",
                    detail = ex.Message,
                    status = StatusCodes.Status500InternalServerError
                })
           );
        }
    }
}
