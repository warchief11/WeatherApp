using System.IO;
using System.Linq;
using System.Web.Http;
using System.Xml.Serialization;
using WeatherApp.Models;
using WeatherApp.Models.GlobalWeatherAPI;

namespace WeatherAppAPI.Controllers
{
    public class LocationsController : ApiController
    {
        private LocationService _locationService;

        public LocationsController()
        {
            _locationService = new LocationService();
        }

        public IHttpActionResult Get(string country)
        {
            return Ok(_locationService.GetLocations(country));
        }
    }
}