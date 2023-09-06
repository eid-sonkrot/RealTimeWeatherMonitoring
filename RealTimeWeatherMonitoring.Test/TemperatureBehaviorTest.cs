using AutoFixture;
using Moq;

namespace RealTimeWeatherMonitoring.Test
{
     
    [TestClass]
    public class TemperatureBehaviorTest
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
        public void Execute_ShouldPrintMessage_WhenTemperatureIsAboveThreshold()
        {
            //Arange
            var weatherData = new WeatherData()
            {
                Temperature = fixture.Create<double>(),
                Humidity = fixture.Create<double>()
            };
            var botBehavior = new TemperatureBehavior();
            var threshold = weatherData.Temperature-1;
            var message = fixture.Create<string>();
            //Act
            Console.SetOut(sw);
            botBehavior.Execute(message, threshold, weatherData);
            var consoleOutput = sw.ToString().Trim();
            //Assert
            Assert.AreEqual(message, consoleOutput);
        }
        [TestMethod]
        public void Execute_ShouldNotPrintMessage_WhenTemperatureIsBelowThreshold()
        {
            //Arange
            var weatherData = new WeatherData()
            {
                Temperature = fixture.Create<double>(),
                Humidity = fixture.Create<double>()
            };
            var botBehavior = new TemperatureBehavior();
            var threshold = weatherData.Temperature + 1;
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
