namespace RealTimeWeatherMonitoring
{
    public interface IObserver
    {
        void Update(WeatherData data);
    }
}
