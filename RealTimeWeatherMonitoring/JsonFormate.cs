using System.Text.Json;

namespace RealTimeWeatherMonitoring
{
    public class JsonFormate : IDataFormate
    {
        private JsonDocument? jsonDoc = null;
        private static JsonFormate? jsonFormate;

        private JsonFormate()
        {
        }
        public static JsonFormate GetJsonFormate()
        {
            if (jsonFormate == null)
            {
                jsonFormate = new JsonFormate();
                return jsonFormate;
            }
            else
            {
                return jsonFormate;
            }
        }
        public bool IsRightFormate(string Data)
        {
            try
            {
                jsonDoc = JsonDocument.Parse(Data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public object GetDocument(string Data)
        {
            if (IsRightFormate(Data))
            {
                if (jsonDoc is not null)
                {
                    return jsonDoc;
                }
                else
                {
                    throw new NullReferenceException("Document object is null");
                }
            }
            else
            {
                throw new FormatException("Invalid data format");
            }
        }
    }

}
