using Microsoft.Extensions.Primitives;


//1. Using the TryGetValue() method, access a header named "UserID" and store it in a variable called "userId".
//   Use an "if" condition to verify if the Request contains such a header.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{

    string method = context.Request.Method;
    context.Request.Headers.TryGetValue("UserID", out StringValues userId);

    if (method == "GET")
    {

        if (!string.IsNullOrEmpty(userId))
        {
            await context.Response.WriteAsync($"<div>MyKey: {userId}</div>");
        }
    }

    //2. Send a query string containing multiple queries in the Request Body using the POST method.
    //   Using Postman, access the string in Visual Studio (VS) and retrieve its values using a break point.

    if (method == "POST")
    {
        string requestBody;
        using (StreamReader reader = new StreamReader(context.Request.Body))
        {
            requestBody = await reader.ReadToEndAsync();
            await context.Response.WriteAsync($"<div>Received request body: {requestBody}</div>");
        }

        Dictionary<string, StringValues> dict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(requestBody);

        foreach (var item in dict)
        {
            await context.Response.WriteAsync($"<div>response: {item}\n</div>");

        }



    };
});

app.Run();
