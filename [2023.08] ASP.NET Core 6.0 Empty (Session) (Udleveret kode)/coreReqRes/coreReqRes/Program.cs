using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);

});

var app = builder.Build();
app.UseSession();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/index.html");
});



app.MapGet("/Login", async context =>
{

    String name = context.Request.Query["Name"];
    String password = context.Request.Query["Password"];

    if (name.Length > 2 && password.Length > 2)
    {

        if (string.IsNullOrEmpty(context.Session.GetString("name")))
        {
            context.Session.SetString("name", name);
            context.Session.SetString("password", password);
        }
        context.Response.Redirect("/varer");
    }
    else
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("wwwroot/index.html");
    }

});


app.MapGet("/varer", async context =>
{
    if (string.IsNullOrEmpty(context.Session.GetString("name")))
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("wwwroot/index.html");

    }
    else
    {
        string na = context.Session.GetString("name");

        if (na == "Rebecca")
        {
            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync("wwwroot/varer.html");
            await context.Response.WriteAsync("<br> velkommen." + context.Session.GetString("name"));
        }
    }
});




app.Run();
