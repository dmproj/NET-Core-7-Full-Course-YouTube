var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//1.Create a middleware pipeline using the Run() and Use() methods.
//  Additionally, add an additional Use() method.


app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var requestPath = context.Request.Path;
    await context.Response.WriteAsync("app.Use() one\n");
    await context.Response.WriteAsync($"{requestPath}\n");

//2.Interrupt the execution of the middleware pipeline using an "if" statement.
    var alwaysTrue = 2 > 1;
    if (alwaysTrue)
    {
        return;
    }

    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var requestPath = context.Request.Path;
    await context.Response.WriteAsync("2nd Run()\n");
    await context.Response.WriteAsync($"{requestPath}\n");
    await next(context);

});

app.Run(async (context) =>
{
    var response = context.Response;
    await context.Response.WriteAsync("3nd Run()\n");
    await context.Response.WriteAsync($"{response}\n");

});

app.Run();
