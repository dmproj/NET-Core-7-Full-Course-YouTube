//1. Execute a handler function using MapGet() function.
app.MapGet("/", () => "Hello World!");

//2. Execute a handler function using Run() function.
app.Run(async (HttpContext context) => ...

//3. Access the Request and Response headers using foreach function
var reqHeaders = context.Request.Headers;
var resHeaders = context.Response.Headers;

foreach (var header in reqHeaders)
{
    Debug.WriteLine("{0}: {1}", header.Key, header.Value);
}

foreach (var header in resHeaders)
{
    Debug.WriteLine("{0}: {1}", header.Key, header.Value);
}


//4. Using Run() function, dispaly any text in the browser as HTML document
context.Response.Headers.Add("Content-Type", "text/html");


//5. Make conditional output using "if" condition
if (reqMethod == "GET")
{
    await context.Response.WriteAsync($"<div>{reqMethod}</div>");
    await context.Response.WriteAsync($"<div>{reqHost}</div>");
}
else
{
    await context.Response.WriteAsync($"<div>{reqPath}</div>");
}

