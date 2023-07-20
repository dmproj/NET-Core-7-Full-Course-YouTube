using MyApp.MyAppCustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next.Invoke();
});

app.UseWhen(context => context.Request.Path == "/api", branch =>
{
    branch.UseCustomMiddleware1();
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Middleware 3\n");
});

app.Run();
