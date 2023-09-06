using AutoFixture;
using Moq;

namespace RealTimeWeatherMonitoring.Test
{

    [TestClass]
    public class SunBotTest
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
            var sunBot = SunBot.GetSunBot();
            var weatherData = fixture.Create<WeatherData>();
            var mockBehavior = new Mock<IBotBehavior>();
            //Act
            mockBehavior.Setup(m => m.Execute(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<WeatherData>())).Verifiable("Execute was never invoked");
            sunBot.behavior = mockBehavior.Object;
            sunBot.Enabled = true;
            //Assert
            sunBot.Update(weatherData);
            mockBehavior.VerifyAll();
        }
        [TestMethod]
        public void Test_GetSunBot_Returns_Instance()
        {
            // Arrange & Act
            var bot = SunBot.GetSunBot();
            var type = bot.GetType();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot, type);
        }
    }
}
