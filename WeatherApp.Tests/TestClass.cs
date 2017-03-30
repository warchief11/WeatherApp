using NUnit.Framework;
using WeatherApp.Models;

namespace WeatherApp.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetWeather_IfCityPassed_ShouldBeValid()
        {
            WeatherService service = new WeatherService();
            service.GetWeather("?q=London,uk");
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
