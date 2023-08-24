using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


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
		
		context.Response.ContentType = "text/html";
		await context.Response.SendFileAsync("wwwroot/varer.html");
	}
	else
	{
		context.Response.ContentType = "text/html";
		await context.Response.SendFileAsync("wwwroot/index.html");
	}
});


app.MapGet("/varer", async context =>
{   
		context.Response.ContentType = "text/html";
		await context.Response.SendFileAsync("wwwroot/varer.html");
});

app.UseSession();

app.Run();

