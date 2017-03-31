using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> Get(string city, string country)
        {
            var weatherDetails = await _weatherService.GetForecastAsync(city, country);
            if(weatherDetails == null)
            {
                return NotFound();
            }
            return Ok(weatherDetails);
        }
    }
}