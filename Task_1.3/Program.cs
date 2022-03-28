using System.Configuration;
using Task_1._3.interfaces;
using Task_1._3.mocks;
using Task_1._3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddMvc();
builder.Services.AddTransient<IPerson, MockPerson>();
var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Person}/{action=Create}");
});

app.Run();
