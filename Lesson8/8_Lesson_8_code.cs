var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//registers the routing middleware in the application pipeline
//This middleware is responsible for mathicng incmoming requests to endpoints
app.UseRouting();

//GetEndpoint() extension method to get endpoint for the current req.
//1.Logging
//2.What middleware will be executed for a req
//3.Inspect the route's path or method
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"GetEndpoint() method: {endPoint}\n");
    }

    await next(context);
});

//registers the enspoints execution middleware in the application pipleine
//This middleare is reposnsible for executing the endpoints that are mathced by the routing middleware
app.UseEndpoints(endpoints =>
{
    //Map, Mapget, MapPost etc used to define endpoints, it takes a URL path and delegate
    //as an input, and the delegate will be executed when a request is received for that URL path
    endpoints.Map("api/map", async (context) =>
    {
        await context.Response.WriteAsync("common method Get");
    });

    endpoints.Map("api/downloads/{filename}.{extension}", async (context) =>
    {
        string filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"Filename to download: {filename}.{extension}");
    });

    endpoints.Map("api/{id=guest}", async (context) =>
    {
        string? id = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"User's ID: {id}");
    });

    endpoints.MapGet("api/mapget", async (context) =>
    {
        await context.Response.WriteAsync("only Get req's");
    });

    endpoints.MapPost("api/mappost", async (context) =>
    {
        await context.Response.WriteAsync("only Post req's");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("only post req's");
});


app.Run();
