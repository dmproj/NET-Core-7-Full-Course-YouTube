using Microsoft.Extensions.FileProviders;
using MyApp.CustomConstraint;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{ WebRootPath = "PublicStaticFolder" });
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("years", typeof(CustomConstraint));
});
var app = builder.Build();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "PublicStaticFolderAdditional"))
});

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    //endpoints.Map("profiles/users-ids/{month:int:min(1):max(12)}/{year:years}", async (context) =>
    //{
    //    string? year = Convert.ToString(context.Request.RouteValues["year"]);
    //    string? month = Convert.ToString(context.Request.RouteValues["month"]);
    //    await context.Response.WriteAsync($"User's reg month: {month}\n");
    //    await context.Response.WriteAsync($"User's reg year: {year}\n");
    //});

    endpoints.Map("a/b", async (context) =>
    {
        string? b = Convert.ToString(context.Request.RouteValues["b"]);
        await context.Response.WriteAsync($"B is triggered: {b}\n");
    });

    endpoints.Map("a/{*c}", async (context) =>
    {
        string? c = Convert.ToString(context.Request.RouteValues["c"]);
        await context.Response.WriteAsync($"C is triggered: {c}\n");
        string? id = context.Request.Query["id"];
        if (id != null)
        {
            await context.Response.WriteAsync($"USER ID: {id}\n");
        }
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("CONSTRAINT WAS NOT TRIGGERED");
});

app.Run();
