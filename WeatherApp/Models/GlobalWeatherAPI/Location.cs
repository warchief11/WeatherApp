using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WeatherApp.Models.GlobalWeatherAPI
{
    [XmlRoot(ElementName = "Table")]
    public class CityDetail
    {
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class CityLists
    {
        [XmlElement(ElementName = "Table")]
        public List<CityDetail> LocationList { get; set; }
    }
}

