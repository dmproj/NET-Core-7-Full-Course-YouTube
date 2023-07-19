//ASP.NET Core 7, Lesson 4
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube


using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    string path = context.Request.Path;
    string method = context.Request.Method;
    var reqHeaders = context.Request.Headers;
    context.Request.Headers.TryGetValue("AuthKey", out StringValues authKey);
    context.Request.Headers.TryGetValue("ID", out StringValues id);


    if (method == "GET")
    {
        if (path == "/")
        {
            await context.Response.WriteAsync($"<div>{path}</div>");
            await context.Response.WriteAsync($"<div>{method}</div>");

            foreach (var header in reqHeaders)
            {
                await context.Response.WriteAsync($"<div>{header.Key}: {header.Value}</div>");
            }

            if (!string.IsNullOrEmpty(authKey))
            {
                await context.Response.WriteAsync($"<div>MyKey: {authKey}</div>");
            }

            if (!string.IsNullOrEmpty(id))
            {
                await context.Response.WriteAsync($"<div>Authorized: {id}</div>");
            }
        }
        else if (path == "/user")
        {
            await context.Response.WriteAsync($"<div>{path}</div>");
            await context.Response.WriteAsync($"<div>{method}</div>");


            if (context.Request.Query.ContainsKey("active") && context.Request.Query.ContainsKey("id"))
            {
                await context.Response.WriteAsync($"<div>Active: {context.Request.Query["active"]}</div>");
                await context.Response.WriteAsync($"<div>ID: {context.Request.Query["id"]}</div>");
            }
            else if (context.Request.Query.ContainsKey("active") && (!context.Request.Query.ContainsKey("id")))
            {
                await context.Response.WriteAsync($"<div>Authorized: {context.Request.Headers["ID"]}</div>");
            }
            else
            {
                await context.Response.WriteAsync($"<div>No query parameters found</div>");
            }

        }
    }
    if (method == "POST")
    {
        string requestBody;
        using (StreamReader reader = new StreamReader(context.Request.Body))
        {
            requestBody = await reader.ReadToEndAsync();
            await context.Response.WriteAsync($"<div>Received request body: {requestBody}</div>");
        }

        Dictionary<string, StringValues> dict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(requestBody);
        var uId = dict["userId"];
        await context.Response.WriteAsync($"<div>first response: {uId}\n</div>");

        foreach (var item in dict)
        {
            await context.Response.WriteAsync($"<div>second response: {item}\n</div>");

        }


    }

});

app.Run();
