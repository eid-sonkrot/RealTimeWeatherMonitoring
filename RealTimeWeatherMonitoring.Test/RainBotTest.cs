using AutoFixture;
using Moq;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class RainBotTest
    {
        private Fixture fixture;

        [TestInitialize]
        public void Setup()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void Test_Update_Method()
        {
            //Arang
            var rainBot = RainBot.GetRainBot();
            var weatherData = fixture.Create<WeatherData>();
            var mockBehavior = new Mock<IBotBehavior>();
            //Act
            mockBehavior.Setup(m => m.Execute(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<WeatherData>())).Verifiable("Send was never invoked");
            rainBot.behavior = mockBehavior.Object;
            rainBot.Enabled = true;
            //Assert
            rainBot.Update(weatherData);
            mockBehavior.VerifyAll();
        }
        [TestMethod]
        public void Test_GetRainBot_Returns_Instance()
        {
            // Arrange & Act
            var bot = RainBot.GetRainBot();
            var type = bot.GetType();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot, type);
        }
    }
}
