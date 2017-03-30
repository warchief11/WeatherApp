using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherApp.Models
{
    public class WeatherService
    {
        public void GetWeather(string urlParams)
        {
            var client = GetOpenWeatherMapClient();
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParams).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<WeatherDetails>().Result;
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            else
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
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