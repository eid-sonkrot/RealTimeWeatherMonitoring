using System.Xml.Linq;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class XmlFormateTest
    {
        [TestMethod]
        public void IsRightFormate_Xml_Check_Valdation()
        {
            //Arange
            var data = "<WeatherData>\r\n  <Location>City Name</Location>\r\n  <Temperature>23.0</Temperature>\r\n  <Humidity>85.0</Humidity>\r\n</WeatherData>";
            var dataFormate = new DataFormateFactory().CreateDataFormate(data);
            //Act
            var result = dataFormate.IsRightFormate(data);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetXDocument_Check_Valdation()
        {
            //Arange
            var data = "<WeatherData>\r\n  <Location>City Name</Location>\r\n  <Temperature>23.0</Temperature>\r\n  <Humidity>85.0</Humidity>\r\n</WeatherData>";
            var dataFormate = new DataFormateFactory().CreateDataFormate(data);
            //Act
            var result = dataFormate.GetDocument(data);
            var except = XDocument.Parse(data);
            //Assert
            Assert.AreEqual(result.ToString(), except.ToString());
        }
    }
}
