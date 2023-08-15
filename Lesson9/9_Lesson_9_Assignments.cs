var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();


app.UseEndpoints(endpoints =>
{
    //create an endpoint using "alpha" constraint
    endpoints.Map("alpha-ids/{id:alpha:minlength(6):maxlength(10)}", async (context) =>
    {
        string? usingAlpha = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"using alpha: {usingAlpha}\n");
    });
    //create an endpoint using "length" constraint
    endpoints.Map("length-ids/{id:int:length(6,10)}", async (context) =>
    {
        string? usingRange = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"using length: {usingRange}\n");
    });
    //create an endpoint using "min max" constraint
    endpoints.Map("min-max/{id:int:min(6):max(10)=10}", async (context) =>
    {
        string? usingMinMax = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"using min max: {usingMinMax}\n");
    });
    //create an endpoint using "regex" constraint
    endpoints.Map("regex-ids/{num-one:int:range(1,100)}/{num-two:regex(^(1|2|3|4|5)$)}", async (context) =>
    {
        string? numOne = Convert.ToString(context.Request.RouteValues["num-one"]);
        string? numTwo = Convert.ToString(context.Request.RouteValues["num-two"]);
        await context.Response.WriteAsync($"using regex: {numOne}\n");
        await context.Response.WriteAsync($"using regex: {numTwo}\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("CONSTRAINT WAS NOT TRIGGERED");
});


app.Run();

