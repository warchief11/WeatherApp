using System;

namespace WeatherApp.Models.openWeatherMapAPI
{
    public class WeatherDetails
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public decimal visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public string dt { get; set; }
        public Sys sys { get; set; }
        public decimal id { get; set; }
        public string name { get; set; }
        public decimal cod { get; set; }
    }

    public class Coord
    {
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }

    public class Main
    {
        public decimal temp { get; set; }
        public decimal pressure { get; set; }
        public decimal humidity { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
    }

    public class Wind
    {
        public decimal speed { get; set; }
        public decimal deg { get; set; }
    }

    public class Clouds
    {
        public decimal all { get; set; }
    }

    public class Sys
    {
        public decimal type { get; set; }
        public decimal id { get; set; }
        public decimal message { get; set; }
        public string country { get; set; }
        public decimal sunrise { get; set; }
        public decimal sunset { get; set; }
    }

    public class Weather
    {
        public decimal id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}