//ASP.NET Core 7, Lesson 2
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{

    context.Response.Headers.Add("Content-Type", "text/html");
    var reqPath = context.Request.Path;
    var reqHost = context.Request.Host;
    var reqMethod = context.Request.Method;
    await context.Response.WriteAsync($"<div>{reqHost}</div>");


    if (reqMethod == "GET")
    {
        if (reqPath == "/user")
        {
            await context.Response.WriteAsync($"<div>{reqPath}</div>");
            await context.Response.WriteAsync($"<div>{reqMethod}</div>");
        }
        else if (reqPath == "/")
        {
            await context.Response.WriteAsync($"<div>!{reqPath}!</div>");
        }
    }
});

app.Run();
