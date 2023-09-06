namespace RealTimeWeatherMonitoring
{
    public class SunBot : Bot
    {
        private static SunBot sunBot;

        private SunBot(IBotBehavior behavior) : base(behavior) { }
        public override void Update(WeatherData weatherData)
        {
            if (Enabled)
                behavior.Execute(Message, Threshold, weatherData);
        }
        public static Bot GetSunBot()
        {
            if (sunBot == null)
            {
                sunBot = new SunBot(new TemperatureBehavior());
            }
            return sunBot;
        }
    }
}
