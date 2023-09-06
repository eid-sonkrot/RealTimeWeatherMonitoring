namespace RealTimeWeatherMonitoring
{
    public abstract class Bot : IObserver
    {
        public IBotBehavior? behavior { set; get; }
        public string Message { set; get; }
        public double Threshold { set; get; }
        public bool Enabled { set; get; }

        protected Bot(IBotBehavior? behavior)
        {
            this.behavior = behavior;
        }
        public abstract void Update(WeatherData weatherData);
    }
}
