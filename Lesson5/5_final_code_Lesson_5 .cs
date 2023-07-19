//ASP.NET Core 7, Lesson 5
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var requestPath = context.Request.Path;
    await context.Response.WriteAsync("app.Use() one\n");
    await context.Response.WriteAsync($"{requestPath}\n");

    var alwaysTrue = 2 > 1;
    if (alwaysTrue)
    {
        return;
    }

    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var requestPath = context.Request.Path;
    await context.Response.WriteAsync("2nd Run()\n");
    await context.Response.WriteAsync($"{requestPath}\n");
    await next(context);

});

app.Run(async (context) =>
{
    var response = context.Response;
    await context.Response.WriteAsync("3nd Run()\n");
    await context.Response.WriteAsync($"{response}\n");

});

app.Run();
