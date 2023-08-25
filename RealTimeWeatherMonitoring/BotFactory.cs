using System.Text.Json;

namespace RealTimeWeatherMonitoring
{
    public class BotFactory : IBotFactory
    {
        private JsonDocument appConfig;
        private const string JsonPath = "C:\\Users\\Smile\\source\\repos\\RealProject\\RealProject\\Configuration.json";

        public BotFactory()
        {
            try
            {
                var jsonString = File.ReadAllText(JsonPath);

                appConfig = (JsonDocument)new DataFormateFactory().CreateDataFormate(jsonString).GetDocument(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Read Config file Error: {ex.Message}");
            }
        }
        public void CreatBots()
        {
            CreatRainBot();
            CreatSnowBot();
            CreatSunBot();
        }
        public void CreatSunBot()
        {
            try
            {
                var bot = SunBot.GetSunBot();
                var sunBot = appConfig.RootElement.GetProperty("SunBot");

                bot.Enabled = sunBot.GetProperty("enabled").GetBoolean();
                bot.Message = sunBot.GetProperty("message").GetString();
                bot.Threshold = sunBot.GetProperty("temperatureThreshold").GetDouble();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SunBot Creat  Error: {ex.Message}");
            }
        }
        public void CreatSnowBot()
        {
            try
            {
                var bot = SnowBot.GetSnowBot();
                var snowBot = appConfig.RootElement.GetProperty("SnowBot");

                bot.Enabled = snowBot.GetProperty("enabled").GetBoolean();
                bot.Message = snowBot.GetProperty("message").GetString();
                bot.Threshold = snowBot.GetProperty("temperatureThreshold").GetDouble();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"rain Bot Creat  Error: {ex.Message}");
            }
        }
        public void CreatRainBot()
        {
            try
            {
                var bot = RainBot.GetRainBot();
                var rainBot = appConfig.RootElement.GetProperty("RainBot");

                bot.Enabled = rainBot.GetProperty("enabled").GetBoolean();
                bot.Message = rainBot.GetProperty("message").GetString();
                bot.Threshold = rainBot.GetProperty("humidityThreshold").GetDouble();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"snow Bot Creat  Error: {ex.Message}");
            }
        }
    }

}
