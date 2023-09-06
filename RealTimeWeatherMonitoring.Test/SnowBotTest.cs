using AutoFixture;
using Moq;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class SnowBotTest
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
            var snowBot = SnowBot.GetSnowBot();
            var weatherData = fixture.Create<WeatherData>();
            var mockBehavior = new Mock<IBotBehavior>();
            //Act
            mockBehavior.Setup(m => m.Execute(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<WeatherData>())).Verifiable("Execute was never invoked");
            snowBot.behavior = mockBehavior.Object;
            snowBot.Enabled = true;
            //Assert
            snowBot.Update(weatherData);
            mockBehavior.VerifyAll();
        }
        [TestMethod]
        public void Test_GetSnowBot_Returns_Instance()
        {
            // Arrange & Act
            var bot = SnowBot.GetSnowBot();
            var type = bot.GetType();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot, type);
        }
    }
}
