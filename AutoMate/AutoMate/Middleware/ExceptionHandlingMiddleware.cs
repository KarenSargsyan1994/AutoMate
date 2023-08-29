using System.Reflection.Metadata;

namespace App.Middleware
{
    internal class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {

        }
    }
}
