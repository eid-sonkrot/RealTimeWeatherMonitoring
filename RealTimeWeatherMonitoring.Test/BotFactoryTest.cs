using AutoFixture;

namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class BotFactoryTest
    {
        private Fixture fixture;
        private BotFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            factory = new BotFactory();
        }
        [TestMethod]
        public void Test_CreatSunBot()
        {
            // Arrange
            var type = typeof(SunBot);
            // Act
            factory.CreatSunBot();
            var bot=SunBot.GetSunBot();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot,type);
        }
        [TestMethod]
        public void Test_CreatSnowBot()
        {
            // Arrange
            var type = typeof(SnowBot);
            // Act
            factory.CreatSnowBot();
            var bot = SnowBot.GetSnowBot();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot, type);
        }
        [TestMethod]
        public void Test_CreatRainBot()
        {
            // Arrange
            var type = typeof(RainBot);
            // Act
            factory.CreatRainBot();
            var bot = RainBot.GetRainBot();
            // Assert
            Assert.IsNotNull(bot);
            Assert.IsInstanceOfType(bot, type);
        }
        [TestMethod]
        public void Test_CreatBots()
        {
            // Arrange
            var snowType = typeof(SnowBot);
            var rainType = typeof(RainBot);
            var sunType = typeof(SunBot);
            // Act
            factory.CreatBots();
            var rainBot = RainBot.GetRainBot();
            var snowBot = SnowBot.GetSnowBot();
            var sunBot = SunBot.GetSunBot();
            // Assert
            Assert.IsNotNull(sunBot);
            Assert.IsNotNull(snowBot);
            Assert.IsNotNull(rainBot);
            Assert.IsInstanceOfType(sunBot, sunType);
            Assert.IsInstanceOfType(rainBot, rainType);
            Assert.IsInstanceOfType(snowBot, snowType);
        }
    }
}