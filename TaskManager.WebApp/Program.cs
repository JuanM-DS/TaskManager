using TaskManager.WebApp.Extensions.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

var confi = builder.Configuration;

builder.Services
    .AddOpenApi()
    .AddFilters()
    .AddValidation()
    .AddMainDbContext(confi);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.Run();
