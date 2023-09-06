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
            if (jsonFormate is null)
            {
                jsonFormate = new JsonFormate();
            }
            return jsonFormate;  
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
            if (!IsRightFormate(Data))
            {
                throw new FormatException("Invalid data format");
            }
            if (jsonDoc is null)
            {
                throw new NullReferenceException("Document object is null");
            }
            return jsonDoc;
        }
    }
}