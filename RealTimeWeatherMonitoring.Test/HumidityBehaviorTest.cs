using AutoFixture;
using Moq;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class HumidityBehaviorTest
    {
        private Fixture fixture;
        private StringWriter sw;

        [TestInitialize]
        public void Setup()
        {
            fixture = new Fixture();
            sw = new StringWriter();
        }
        [TestMethod]
        public void Execute_ShouldPrintMessage_WhenHumidityIsAboveThreshold()
        {
            //Arange
            var weatherData = new WeatherData()
            {
                Temperature = fixture.Create<double>(),
                Humidity = fixture.Create<double>()
            };
            var botBehavior = new HumidityBehavior();
            var threshold = weatherData.Humidity - 1;
            var message = fixture.Create<string>();
            //Act
            Console.SetOut(sw);
            botBehavior.Execute(message, threshold, weatherData);
            var consoleOutput = sw.ToString().Trim();
            //Assert
            Assert.AreEqual(message, consoleOutput);
        }
        [TestMethod]
        public void Execute_ShouldNotPrintMessage_WhenHumidityIsBelowThreshold()
        {
            //Arange
            var weatherData = new WeatherData()
            {
                Temperature = fixture.Create<double>(),
                Humidity = fixture.Create<double>()
            };
            var botBehavior = new HumidityBehavior();
            var threshold = weatherData.Humidity + 1;
            var message = fixture.Create<string>();
            //Act
            Console.SetOut(sw);
            botBehavior.Execute(message, threshold, weatherData);
            var consoleOutput = sw.ToString().Trim();
            //Assert
            Assert.AreEqual("", consoleOutput);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            sw.Dispose();
        }
    }
}
