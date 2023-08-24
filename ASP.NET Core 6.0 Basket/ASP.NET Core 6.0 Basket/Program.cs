
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// The Application starts on the Index.cshtml page
app.MapRazorPages();
app.MapGet("/", context =>
{
    context.Response.ContentType = "text/html";
    context.Response.SendFileAsync("Pages/Index.cshtml");
    return Task.CompletedTask;
});


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();