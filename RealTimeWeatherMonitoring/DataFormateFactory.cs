namespace RealTimeWeatherMonitoring
{
    public class DataFormateFactory : IDataFormateFactory
    {
        public IDataFormate CreateDataFormate(string Data)
        {
            switch (true)
            {
                case true when JsonFormate.GetJsonFormate().IsRightFormate(Data):
                    return JsonFormate.GetJsonFormate();
                case true when XmlFormate.GetXmlFormate().IsRightFormate(Data):
                    return XmlFormate.GetXmlFormate();
                default:
                    throw new FormatException("Invalid data format");
            }
        }
    }
}
