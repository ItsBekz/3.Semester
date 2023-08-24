var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/hej", () => "Hello World!");
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("web/index.html");
});

app.MapPost("/Login", async (context) =>
{
    string name = context.Request.Form["fname"];
    await context.Response.WriteAsync("Welcome " + name);
});



app.Run();

