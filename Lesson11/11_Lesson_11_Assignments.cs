using Microsoft.Extensions.FileProviders;
using MyApp.CustomConstraint;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
//register a custom static folder using builder
    WebRootPath = "PublicStaticFolder"
});
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("years", typeof(CustomConstraint));
});
var app = builder.Build();
// register wwwroot public static folder using UseStaticFiles();
app.UseStaticFiles();  

// register additional custom static folder, combine it with previous folders to be accessable.
app.UseStaticFiles(new StaticFileOptions() { FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "PublicStaticFolderAdditional"))});

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.Map("profiles/users-ids/{month:int:min(1):max(12)}/{year:years}", async (context) =>
    {
        string? year = Convert.ToString(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"User's reg month: {month}\n");
        await context.Response.WriteAsync($"User's reg year: {year}\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("CONSTRAINT WAS NOT TRIGGERED");
});

app.Run();
