var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.Map("/postuser", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var form = context.Request.Form;
    string name = form["name"];
    string age = form["age"];
    await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");

});

app.Run();