namespace DemoApp.Backend.Models;
public record WeatherForecast(int Id, DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record WeatherForecastResponse(
    string Location,
    List<HourlyForecastResponse> TodaysForecast,
    List<ForecastResponse> WeeklyForecast);

public record ForecastResponse(
    string Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);


public record HourlyForecastResponse(
    string Hour,
    string Summary,
    int TemperatureC)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}