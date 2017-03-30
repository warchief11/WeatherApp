using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WeatherApp.Models.GlobalWeatherAPI
{
    public class LocationService
    {
        public List<Location> GetLocations(string country)
        {
            var weatherAppClient = new WeatherApp.GlobalWeatherServiceRef.GlobalWeatherSoapClient();
            string cities = weatherAppClient.GetCitiesByCountry(country);
            XmlSerializer serializer = new XmlSerializer(typeof(CityLists));
            using (TextReader textReader = new StringReader(cities))
            {
                var obj = (CityLists)serializer.Deserialize(textReader);
                return obj.LocationList.Select(x => new Location { City = x.City, Country = x.Country }).ToList();
            }
        }
    }
}