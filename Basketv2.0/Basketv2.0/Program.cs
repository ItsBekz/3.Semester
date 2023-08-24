using Basketv2._0;
using System.IO;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DBController dBController = new DBController();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    string loginPage = await File.ReadAllTextAsync("wwwroot/index.html");
    await context.Response.WriteAsync(loginPage);
});

app.MapPost("/", async context =>
{

    string username = context.Request.Form["username"];
    string password = context.Request.Form["password"];

    //can't seem to connect to the database, so I'm just going to assume that the user exists
    //for test purposes
    //bool userExists = dBController.CheckUser(username, password);

    bool userExists = true;

    if (userExists)
    {
        context.Response.Redirect("wwwroot/products.html");
    }
    else
    {
        context.Response.Redirect("/");
        
    }
});

app.MapGet("wwwroot/products.html", async context =>
{
    context.Response.ContentType = "text/html";
    string productsHtml = dBController.GetProducts();
    await context.Response.WriteAsync(productsHtml);
});

app.MapPost("wwwroot/products.html", async context =>
{
    
});

app.Run();

