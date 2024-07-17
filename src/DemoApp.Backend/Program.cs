using DemoApp.Backend.Data;
using DemoApp.Backend.Models;
using DemoApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsql<ApplicationDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection")
);
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyInDevelopment", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });

    options.AddPolicy("AllowFrontendInProd", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy.WithOrigins("https://demo.thedevstartup.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAnyInDevelopment");
}
else
{
    app.UseCors("AllowFrontendInProd");
}


app.UseHttpsRedirection();



using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
    catch
    {
        throw new Exception("Failed to create database");
    }
}

app.MapGet("/weatherforecast", ([FromServices] WeatherForecastService ws) =>
{
    var forecast = ws.GetWeatherForecast();
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecast")
.WithOpenApi()
.Produces<WeatherForecastResponse>(StatusCodes.Status200OK);

app.Run();

