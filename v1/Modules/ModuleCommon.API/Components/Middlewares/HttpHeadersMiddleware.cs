using CoreCommon.Application.API.Base;
using Microsoft.AspNetCore.Http;

namespace ModuleCommon.API.Components.Middlewares
{
    /// <summary>
    /// Http Middleware to manipulate headers
    /// </summary>
    public class HttpHeadersMiddleware : MiddlewareBase
    {
        public HttpHeadersMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override void PreInvoke(HttpContext context)
        {
            //context.Response.Headers["X-Frame-Options"] = "DENY";
            //context.Response.Headers["X-Content-Type-Options"] = "NOSNIFF";
            ////context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; style-src 'self' 'unsafe-inline'; img-src 'self'; font-src 'self'; script-src 'self' 'unsafe-inline'";
            //context.Response.Headers["X-Permitted-Cross-Domain-Policies"] = "master-only";
            //context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
            //context.Response.Headers["Referrer-Policy"] = "origin";
            //context.Response.Headers["Public-Key-Pins"] = "max-age=0; includeSubDomains";
        }

        public override void AfterInvoke(HttpContext context)
        {
            
        }
    }
}
