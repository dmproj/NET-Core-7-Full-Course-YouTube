using MyApp.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
options.ConstraintMap.Add("years", typeof(CustomConstraint));
});
var app = builder.Build();

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
