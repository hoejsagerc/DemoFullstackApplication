using DemoApp.Backend.Data;
using DemoApp.Backend.Models;

namespace DemoApp.Backend.Services;

public class WeatherForecastService
{
    private readonly ApplicationDbContext _context;
    private List<string> _summaries = new Summaries().SummariesList;
    private List<string> _locations = new List<string>
    {
        "Seattle", "New York", "Los Angeles", "Chicago", "Miami"
    };

    public WeatherForecastService(ApplicationDbContext context)
    {
        _context = context;
    }

    public WeatherForecastResponse GetWeatherForecast()
    {
        List<ForecastResponse> weeklyForecast = GenerateWeeklyForecast();
        List<HourlyForecastResponse> dailyForecast = GenerateTodaysForecast();

        return new WeatherForecastResponse(
            GetRandomLocation(),
            dailyForecast,
            weeklyForecast
        );
    }

    private List<ForecastResponse> GenerateWeeklyForecast()
    {
        List<ForecastResponse> weeklyForecast = new List<ForecastResponse>();
        for (int i = 0; i < 7; i++)
        {
            WeatherForecast forecast = GetRandomForecast();
            weeklyForecast.Add(new ForecastResponse(
                DateTime.Now.AddDays(i).ToString("dddd, dd/MM"),
                forecast.TemperatureC,
                forecast.TemperatureF,
                forecast.Summary
            ));
        }

        return weeklyForecast;
    }

    private List<HourlyForecastResponse> GenerateTodaysForecast()
    {
        List<HourlyForecastResponse> dailyForecast = new List<HourlyForecastResponse>();
        DateTime startOfToday = DateTime.Now;

        for (int hour = 0; hour < 5; hour++)
        {
            DateTime currentHour = startOfToday.AddHours(hour);
            dailyForecast.Add(new HourlyForecastResponse(
                currentHour.ToString("HH tt"),
                GetRandomSummary(),
                GetRandomTemperature(20)
            ));
        }

        return dailyForecast;
    }

    private string GetRandomLocation()
    {
        Random random = new Random();
        int index = random.Next(_locations.Count);
        return _locations[index];
    }


    private int GetRandomTemperature(int temp)
    {
        Random random = new Random();
        int randomTemp = random.Next(temp - 5, temp + 6);
        return randomTemp;
    }

    private WeatherForecast GetRandomForecast()
    {
        var forecasts = _context.WeatherForecasts.ToList();
        Random random = new Random();
        int index = random.Next(forecasts.Count);
        var randomForecast = forecasts[index];
        return randomForecast;
    }

    private string GetRandomSummary()
    {
        Random random = new Random();
        int index = random.Next(_summaries.Count);
        return _summaries[index];
    }
}