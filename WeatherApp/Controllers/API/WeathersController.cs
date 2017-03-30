using System.Web.Http;
using WeatherApp.Models.openWeatherMapAPI;

namespace WeatherAppAPI.Controllers
{
    [Route("api/forecasts")]
    public class ForecastsController : ApiController
    {
        private IWeatherService _weatherService;

        public ForecastsController()
        {
            _weatherService = new WeatherService();
        }

        public ForecastsController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IHttpActionResult Get(string city, string country)
        {
            var weatherDetails = _weatherService.GetForecast(city, country);
            if(weatherDetails == null)
            {
                return NotFound();
            }
            return Ok(weatherDetails);
        }
    }
}