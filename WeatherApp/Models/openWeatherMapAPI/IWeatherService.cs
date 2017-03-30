namespace WeatherApp.Models.openWeatherMapAPI
{
    public interface IWeatherService
    {
        Forecast GetForecast(string city, string country);
    }
}