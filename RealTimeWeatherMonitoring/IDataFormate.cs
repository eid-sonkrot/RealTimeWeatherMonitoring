namespace RealTimeWeatherMonitoring
{
    public interface IDataFormate
    {
        public bool IsRightFormate(string Data);
        public object GetDocument(string Data);
    }
}
