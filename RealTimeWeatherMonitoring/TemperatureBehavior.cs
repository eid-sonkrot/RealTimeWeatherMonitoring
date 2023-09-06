namespace RealTimeWeatherMonitoring
{
    public class TemperatureBehavior : IBotBehavior
    {
        public void Execute(string message, double threshold, WeatherData weatherData)
        {
            if (weatherData.Temperature >= threshold)
            {
                Console.WriteLine(message);
            }
        }
    }
}