namespace MyApp.MyAppCustomMiddleware
{
    public class MyAppMiddleware1
    {
        private readonly RequestDelegate _next;

        public MyAppMiddleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("1. Custom middleware: started\n");

            // add check to the lesson code with "if" to verify if the query string contains car=white
            string query = context.Request.Query["car"];
            if (query == "white")
            {
                await context.Response.WriteAsync("The car is white!\n");
            }

            await _next(context);
            await context.Response.WriteAsync("5. Custom middleware: completed\n");
        }
    }

    public static class MiddlewareExtensions1
    {
        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyAppMiddleware1>();
        }
    }
}
