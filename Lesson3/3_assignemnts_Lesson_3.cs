//ASP.NET Core 7, Lesson 3
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//1. Access the Request Headers using the Run() method
//   and iterate over the received results, then display all results
//   in the browser

app.Run(async (HttpContext context) =>
{
    context.Response.Headers.Add("Content-Type", "text/html");
    var reqHeaders = context.Request.Headers;

    foreach (var header in reqHeaders)
    {
        await context.Response.WriteAsync($"<div>{header.Key} " +
            $": {header.Value}</div>");
    }
});
//2. Create an "if" statement which verifies if a header named "authKey"
//   is attached to the Request headers, if it's, then display
//   a message in the browser in HTML format, if the header is not attached
//   to the Request, then display a message "not authorised".

bool isAuthorized = false;
var reqHeaders = context.Request.Headers;

foreach (var header in reqHeaders)
{
    if (header.Key == "auth")
    {
        await context.Response.WriteAsync($"<div>{header.Key}: " +
        $"{header.Value}</div>");
        isAuthorized = true;
        break;
    }
}

if (!isAuthorized)
{
    await context.Response.WriteAsync($"<div>not authorized!</div>");
}


app.Run();
