using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherApp.Models.openWeatherMapAPI
{
    public class WeatherService : IWeatherService
    {
        public Forecast GetForecast(string city, string country)
        {
            var client = GetOpenWeatherMapClient();
            // List data response.
            HttpResponseMessage response = client.GetAsync(string.Format("?q={0},{1}&units=metric", city, country)).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {

                // Parse the response body. Blocking!
                //var weatherDetail = response.Content.ReadAsStringAsync().Result;
                string detail = response.Content.ReadAsStringAsync().Result;
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

        private HttpClient GetOpenWeatherMapClient()
        {
           string URL = "http://api.openweathermap.org/data/2.5/weather";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", "090ac9d4a0b5d54c2083de2e46b65058");

            return client;
        
        }
    }
}