﻿using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace SE.WebApp.MVC.Extensions
{
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
            catch(CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex);
            }
        }

        public static void HandleRequestExceptionAsync(HttpContext context, CustomHttpRequestException httpRequestException)
        {
            if(httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect(location: "/login");
                return;
            }
            context.Response.StatusCode = (int)httpRequestException.StatusCode;
        }
    }
}
