namespace RealTimeWeatherMonitoring
{
    public class HumidityBehavior : IBotBehavior
    {
        public void Execute(string message, double threshold, WeatherData weatherData)
        {
            if (weatherData.Humidity >= threshold)
            {
                Console.WriteLine(message);
            }
        }
    }
}
