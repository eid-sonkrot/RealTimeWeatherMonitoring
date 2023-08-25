using AutoFixture;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class SnowBotTest
    {
        [TestMethod]
        public void Test_Update_Method()
        {
            //Arange
            var snowBot = SnowBot.GetSnowBot();
            var fixture = new Fixture();
            var weatherData = fixture.Create<WeatherData>();
            //Act
            //Assert
            snowBot.Update(weatherData);
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
