//ASP.NET Core 7, Lesson 3
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers.Add("Content-Type", "text/html");

    var reqHeaders = context.Request.Headers;
    bool isAuthorized = false;

    foreach (var header in reqHeaders)
    {
        if (header.Key == "auth")
        {
            await context.Response.WriteAsync($"<div>{header.Key}: {header.Value}</div>");
            isAuthorized = true;
            break;
        }
    }

    if (!isAuthorized)
    {
        await context.Response.WriteAsync($"<div>not authorized!</div>");
    }



});

app.Run();
