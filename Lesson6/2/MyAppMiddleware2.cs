namespace MyApp.MyAppCustomMiddleware
{
    public class MyAppMiddleware2
    {
        private readonly RequestDelegate _next;

        public MyAppMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            await context.Response.WriteAsync("Custom Middleware 2 - After\n");
        }
    }

    public static class MiddlewareExtensions2
    {
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyAppMiddleware2>();
        }
    }
}
