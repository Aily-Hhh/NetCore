using Task_1;

var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<IHelloWorld, HelloWorld>();
var app = builder.Build();

app.Run(async context =>
{
    var service = app.Services.GetService<IHelloWorld>();
    await context.Response.WriteAsync($"{service?.Hello}");
});

app.Run();
