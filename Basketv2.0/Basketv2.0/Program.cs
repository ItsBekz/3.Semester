using Basketv2._0.Models;
using Basketv2._0;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DBController dBController = new DBController();
HTMLBuilder htmlBuilder = new HTMLBuilder();
User currentUser = new User();

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

    currentUser = dBController.GetUsers().Find(x => x.username == username);

    bool userExists = dBController.CheckUser(username, password);

    //bool userExists = true;

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
    string productsHtml = htmlBuilder.GenerateProductHtml(dBController.GetProducts());
    await context.Response.WriteAsync(productsHtml);
});

app.MapPost("/basket", async context =>
{
    string name = context.Request.Form["name"];
    Product product = dBController.GetProducts().Find(x => x.name == name);
    dBController.BuyProduct(currentUser, product);
    context.Response.ContentType = "text/html";
    string basketHtml = htmlBuilder.GenerateBasketHtml(Basket.listBasket);
    await context.Response.WriteAsync(basketHtml);
});

app.UseStaticFiles();
app.Run();
