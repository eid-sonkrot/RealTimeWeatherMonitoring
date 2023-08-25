namespace RealTimeWeatherMonitoring.Test
{
    [TestClass]
    public class BotFactoryTest
    {
        [TestMethod]
        public void Test_BotFactory()
        {
            // Arrange
            // Act
            // Assert
            var factory = new BotFactory();
        }
        [TestMethod]
        public void Test_CreatSunBot()
        {
            // Arrange
            var factory = new BotFactory();
            // Act
            // Assert
            factory.CreatSunBot();
        }
        [TestMethod]
        public void Test_CreatSnowBot()
        {
            // Arrange
            var factory = new BotFactory();
            // Act
            // Assert
            factory.CreatSnowBot();
        }
        [TestMethod]
        public void Test_CreatRainBot()
        {
            // Arrange
            var factory = new BotFactory();
            // Act
            // Assert
            factory.CreatRainBot();
        }
        [TestMethod]
        public void Test_CreatBots()
        {
            // Arrange
            var factory = new BotFactory();
            // Act
            // Assert
            factory.CreatBots();
        }
    }
}
