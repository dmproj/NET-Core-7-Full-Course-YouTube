using MyApp.MyAppCustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Will be executed first\n");
    await next.Invoke();
});

//1. Create an app using UseWhen() method which displays a message

app.UseWhen(context => context.Request.Path == "/api", branch =>
{
    branch.UseCustomMiddleware1();
});


//2. Amend the created app and use the MapWhen() mwthod to create branching

app.MapWhen(context => context.Request.Path == "/branch", branch =>
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
