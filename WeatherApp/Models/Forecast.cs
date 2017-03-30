using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class Forecast
    {
        public Location Location { get; set; }
        public string DateTimeUTC { get; set; }
        public decimal Visibility { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal WindDegree { get; set; }
        public string SkyConditions { get; set; }
        public string Icon { get; set; }
        public decimal Temperature { get; set; }
        public decimal MaxTemp { get; set; }
        public decimal MinTemp { get; set; }
        public string DewPoint { get; set; }
        public decimal RelativeHumdity { get; set; }
        public decimal Pressure { get; set; }
    }
}