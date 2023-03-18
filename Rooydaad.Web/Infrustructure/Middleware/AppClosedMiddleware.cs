using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Rooydaad.Web.Infrustructure.Middleware
{
    public class AppClosedMiddleware
    {
        private readonly RequestDelegate _next;

        public AppClosedMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (Startup.IsWebSiteOpened)
                await _next(context);
            else
                await context.Response.WriteAsync("The WebSite is Closed!");
        }
    }
}
