//ASP.NET Core 7, Lesson 6
//https://github.com/dmproj/NET-Core-7-Full-Course-YouTube

using MyApp.MyAppCustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();


app.UseMiddleware<CustomMiddleware>();

app.Run(async (context) =>
{
    var response = context.Response;
    await context.Response.WriteAsync("Terminal Run() method executed\n");
    await context.Response.WriteAsync($"{response}\n");

});

app.Run();
