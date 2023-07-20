using MyApp.MyAppCustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next.Invoke();
});

app.MapWhen(context => context.Request.Path == "/api", branch =>
{
    branch.UseCustomMiddleware1();
    branch.Run(async context =>
    {
        // Middleware 3
        await context.Response.WriteAsync("Branch Middleware\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Middleware 3\n");
});

app.Run();
