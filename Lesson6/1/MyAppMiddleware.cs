namespace MyApp.MyAppCustomMiddleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("1. Custom middleware: started\n");
            await next(context);
            await context.Response.WriteAsync("3. Custom middleware: completed\n");
        }
    }
}
