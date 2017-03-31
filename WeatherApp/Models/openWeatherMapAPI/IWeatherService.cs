using System.Threading.Tasks;

namespace WeatherApp.Models.openWeatherMapAPI
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecastAsync(string city, string country);
    }
}