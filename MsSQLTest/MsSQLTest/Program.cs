using System.Data.SqlClient;
String databaseConnection()
{
    string SQLServerDBConnectionString = "server=mysql91.unoeuro.com;uid=lightsandbox_dk;pwd=yAzp3ndRxegcDrHkhafm;database=lightsandbox_dk_db";

    String answer = "<html>";
    using (SqlConnection connection = new SqlConnection(SQLServerDBConnectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("SELECT * FROM music", connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var artist = reader.GetString(0);
                    var song = reader.GetString(1);
                    var year = reader.GetInt32(2);
                    var CoverArt = reader.GetString(3);
                    answer += "<div>" + artist + ":" + song + ":" + year + ":" + "<img src =" + CoverArt + "; width=50px>" + "</div> <br>";
                }
            }
        }
    }
    return answer + "</html>";
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    string loginPage = await File.ReadAllTextAsync("wwwroot/Login.html");
    await context.Response.WriteAsync(loginPage);
});

app.MapPost("website/music.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(databaseConnection());
});

app.Run();
