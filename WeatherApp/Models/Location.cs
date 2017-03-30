using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WeatherApp.Models
{
    //public class Location
    //{
    //    public string City { get; set; }
    //    public string Country { get; set; }
    //}

    [XmlRoot(ElementName = "Table")]
    public class Location
    {
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class Locations
    {
        [XmlElement(ElementName = "Table")]
        public List<Location> LocationList { get; set; }
    }
}

