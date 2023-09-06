namespace RealTimeWeatherMonitoring
{
    public interface IDataFormateFactory
    {
        IDataFormate CreateDataFormate(string Data);
    }
}
