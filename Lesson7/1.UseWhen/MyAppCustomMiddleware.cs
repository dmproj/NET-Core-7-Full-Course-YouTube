namespace MyApp.MyAppCustomMiddleware
{
    public class MyAppMiddleware1
    {
        private readonly RequestDelegate _next;

        public MyAppMiddleware1(RequestDelegate next, IApplicationBuilder app)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("CustomMiddleware\n");
            await _next(context);
            
        }
    }

    public static class MiddlewareExtensions1
    {
        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyAppMiddleware1>(app);
        }
    }
}
