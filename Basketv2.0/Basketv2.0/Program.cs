using Basketv2._0.Models;
using Basketv2._0;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Register.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

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
        await context.Response.WriteAsync(HtmlErrorMessage("Wrong credentials. Please try again", "wwwroot/index.html"));
    }
});

app.MapPost("/register", async context =>
{
    string username = context.Request.Form["username"];
    string password = context.Request.Form["password"];
    string confirmPassword = context.Request.Form["confirmPassword"];
    bool checkDoesPasswordsMatch = true;
    bool checkIfUserExists = false;

    if(password != confirmPassword)
    {
        await context.Response.WriteAsync(HtmlErrorMessage("Passwords do not match.", "wwwroot/register.html"));
        checkDoesPasswordsMatch = false;
    }
    
    if(dBController.GetUsers().Any(x => x.username == username))
    {
        await context.Response.WriteAsync(HtmlErrorMessage("Username already exists", "wwwroot/register.html"));
        checkIfUserExists = true;
    }
    if(checkDoesPasswordsMatch == true && checkIfUserExists == false)
    {
        dBController.AddNewUser(username, password);
        string newSuccessMessage = "<p class=\"succes-message\" id=\"\"successMessage\" style=\"color:green;\">You have been registered. You can now login</p>";
        string htmlContent = File.ReadAllText("wwwroot/index.html");
        string oldSuccessMessage = "<p class=\"succes-message\" id=\"\"successMessage\"></p>";
        htmlContent = htmlContent.Replace(oldSuccessMessage, newSuccessMessage);
        await context.Response.WriteAsync(htmlContent);
    }
});

app.MapGet("wwwroot/products.html", async context =>
{
    context.Response.ContentType = "text/html";
    string productsHtml = htmlBuilder.GenerateProductHtml(dBController.GetProducts());
    await context.Response.WriteAsync(productsHtml);
});

app.MapPost("/products", async context =>
{
    context.Response.ContentType = "text/html";
    string productsHtml = htmlBuilder.GenerateProductHtml(dBController.GetProducts());
    await context.Response.WriteAsync(productsHtml);
});

app.MapPost("/basket", async context =>
{
    string name = context.Request.Form["Btn"];
    if (name != null) 
    {
        Product product = dBController.GetProducts().Find(x => x.name == name);
        dBController.BuyProduct(currentUser, product);
    }
    context.Response.ContentType = "text/html";
    string basketHtml = htmlBuilder.GenerateBasketHtml(dBController.UsersBasket(currentUser), currentUser, dBController);
    await context.Response.WriteAsync(basketHtml);
});



string HtmlErrorMessage(string errorMessage, string filePath)
{
    string newErrorMessage = $"<p class=\"error-message\" id=\"errorMessage\" style=\"color: red;\">{errorMessage}</p>";
    string htmlContent = File.ReadAllText(filePath);
    string oldErrorMessage = "<p class=\"error-message\" id=\"errorMessage\"></p>";
    htmlContent = htmlContent.Replace(oldErrorMessage, newErrorMessage);
    return htmlContent;
}

app.UseSession();
app.UseRouting();
app.UseStaticFiles();
app.Run();
