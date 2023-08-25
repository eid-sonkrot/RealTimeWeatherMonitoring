using Moq;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class TemperatureBehaviorTest
    {
        [TestMethod]
        public void Test_Temperature_Execute_Behavior()
        {
            //Arange
            var weatherData = new WeatherData()
            {
                Temperature = 90,
                Humidity = 1000
            };
            var botBehaviorMock = new Mock<TemperatureBehavior>();
            var botBehavior = botBehaviorMock.Object;
            var threshold = 50;
            var message = "wewew";
            //Act
            //Assert
            botBehavior.Execute(message, threshold, weatherData);
        }
    }
}
