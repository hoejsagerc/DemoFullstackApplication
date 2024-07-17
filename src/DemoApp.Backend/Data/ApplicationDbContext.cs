using DemoApp.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var summaries = new Summaries().SummariesList.ToArray();

        var forecasts = new WeatherForecast[20];
        for (int i = 0; i < 20; i++)
        {
            forecasts[i] = new WeatherForecast
            (
                Id: i + 1,
                Date: DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                TemperatureC: Random.Shared.Next(-20, 55),
                Summary: summaries[Random.Shared.Next(summaries.Length)]
            );
        }

        modelBuilder.Entity<WeatherForecast>().HasData(forecasts);
    }
}