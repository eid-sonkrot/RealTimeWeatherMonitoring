using System.Text.Json;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class JsonFormateTest
    {
        [TestMethod]
        public void IsRightFormate_Xml_Check_Valdation()
        {
            //Arange
            var data = "\r\n{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 23.0,\r\n  \"Humidity\": 85.0\r\n}";
            var dataFormate = new DataFormateFactory().CreateDataFormate(data);

            //Act
            var result = dataFormate.IsRightFormate(data);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetJsonDocument_Check_Valdation()
        {
            //Arange
            var data = "\r\n{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 23.0,\r\n  \"Humidity\": 85.0\r\n}";
            var dataFormate = new DataFormateFactory().CreateDataFormate(data);
            //Act
            var result = dataFormate.GetDocument(data);
            var except = JsonDocument.Parse(data);
            //Assert
            Assert.AreEqual(result.ToString(), except.ToString());
        }
    }
}