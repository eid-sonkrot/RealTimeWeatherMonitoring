namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class DataFormateFactoryTest
    {
        [TestMethod]
        public void Test_CreateDataFormate_Returns_IDataFormate_Instance()
        {
            var Data = "\r\n{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 23.0,\r\n  \"Humidity\": 85.0\r\n}";
            var obj = new DataFormateFactory().CreateDataFormate(Data);
            var type = typeof(IDataFormate);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, type);
        }
    }
}
