namespace RealTimeWeatherMonitoring
{
    public interface IBotFactory
    {
        public void CreatBots();
        protected void CreatSunBot();
        protected void CreatSnowBot();
        protected void CreatRainBot();
    }
}
