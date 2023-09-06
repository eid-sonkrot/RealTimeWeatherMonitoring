namespace RealTimeWeatherMonitoring
{
    public class RainBot : Bot
    {
        private static RainBot rainBot;

        private RainBot(IBotBehavior behavior) : base(behavior) { }
        public override void Update(WeatherData weatherData)
        {
            if (Enabled)
            {
                behavior.Execute(Message, Threshold, weatherData);
            }
        }
        public static Bot GetRainBot()
        {
            if (rainBot == null)
            {
                rainBot = new RainBot(new HumidityBehavior());
            }
            return rainBot;
        }
    }
}
