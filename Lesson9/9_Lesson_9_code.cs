var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();


app.UseEndpoints(endpoints =>
{


    endpoints.Map("profiles/users-ids/{month:int:range(1,12)}/{year:regex(^(2023|2024)$)}", async (context) =>
    {
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        string? year= Convert.ToString(context.Request.RouteValues["year"]);
        await context.Response.WriteAsync($"User's reg month: {month}\n");
        await context.Response.WriteAsync($"User's reg year: {year}\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("CONSTRAINT WAS NOT TRIGGERED");
});


app.Run();

