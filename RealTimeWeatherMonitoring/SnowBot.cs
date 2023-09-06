namespace RealTimeWeatherMonitoring
{
    public class SnowBot : Bot
    {
        private static SnowBot snowBot;

        private SnowBot(IBotBehavior behavior) : base(behavior) { }
        public override void Update(WeatherData weatherData)
        {
            if (Enabled)
            {
                weatherData.Temperature *= -1;
                behavior.Execute(Message, Threshold * -1, weatherData);
            }
        }
        public static Bot GetSnowBot()
        {
            if (snowBot == null)
            {
                snowBot = new SnowBot(new TemperatureBehavior());
            }
            return snowBot;
        }
    }
}
