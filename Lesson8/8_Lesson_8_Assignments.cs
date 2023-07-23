var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

//1. Register routing using UseRouting(), UseEnpoints() and MapGet()/MapPost() methods.
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"My endpoint info: {endPoint}\n");
    }

    await next(context);
});

//2. Get endpoints using EndPoints() method.
app.UseEndpoints(endpoints =>
{
    endpoints.Map("mapreq", async (context) =>
    {
        await context.Response.WriteAsync("common method Get");
    });

//3. Register an endpoint for an unterpolation string and a default value.
    endpoints.Map("mapreq/{filename}.{extension}", async (context) =>
    {
        string filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"Filename to download: {filename}.{extension}");
    });

    endpoints.Map("mapreq/choice/{color=yellow}", async (context) =>
    {
        string? color = Convert.ToString(context.Request.RouteValues["color"]);
        await context.Response.WriteAsync($"User's color choice: {color}");
    });

    endpoints.MapGet("mapgetreq", async (context) =>
    {
        await context.Response.WriteAsync("Map Req");
    });

    endpoints.MapPost("mappostreq", async (context) =>
    {
        await context.Response.WriteAsync("Post Req");
    });
});

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("only post req's");
//});


app.Run();
