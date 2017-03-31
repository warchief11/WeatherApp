using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WeatherApp.Models.openWeatherMapAPI
{
    public class WeatherService : IWeatherService
    {
        private const string OpenWeatherBaseURL = "http://api.openweathermap.org/data/2.5/weather";
        private HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(OpenWeatherBaseURL);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "090ac9d4a0b5d54c2083de2e46b65058");
        }

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Forecast> GetForecastAsync(string city, string country)
        {
            // List data response.
            var response = await _httpClient.GetAsync(string.Format("?q={0},{1}&units=metric", city, country));  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                string detail = await response.Content.ReadAsStringAsync();
                var weatherDetail = JsonConvert.DeserializeObject<WeatherDetails>(detail);
                return MapWeatherDetail(city, country, weatherDetail);
            }
            else
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        private static Forecast MapWeatherDetail(string city, string country, WeatherDetails weatherDetail)
        {
            Forecast forecast = new Forecast();
            forecast.Location = new Location { City = city, Country = country, Latitude = weatherDetail.coord.lat, Longitude = weatherDetail.coord.lon };
            forecast.DateTimeUTC = weatherDetail.dt;
            if (weatherDetail.weather.Length > 0)
            {
                forecast.SkyConditions = weatherDetail.weather[0].description;
                forecast.Icon = string.Format("http://openweathermap.org/img/w/{0}.png", weatherDetail.weather[0].icon);
            }
            forecast.Pressure = weatherDetail.main.pressure;
            forecast.RelativeHumdity = weatherDetail.main.humidity;
            forecast.Temperature = weatherDetail.main.temp;
            forecast.MaxTemp = weatherDetail.main.temp_max;
            forecast.MinTemp = weatherDetail.main.temp_min;
            forecast.Visibility = weatherDetail.visibility / 1000;
            if (weatherDetail.wind != null)
            {
                forecast.WindSpeed = weatherDetail.wind.speed;
                forecast.WindDegree = weatherDetail.wind.deg;
            }
            return forecast;
        }
        
    }
}