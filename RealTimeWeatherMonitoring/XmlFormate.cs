using System.Xml;
using System.Xml.Linq;

namespace RealTimeWeatherMonitoring
{
    public class XmlFormate : IDataFormate
    {
        private XDocument? xmlDoc = null;
        private static XmlFormate? xmlFormate;

        private XmlFormate()
        {
        }
        public static XmlFormate GetXmlFormate()
        {
            if (xmlFormate is null)
            {
                xmlFormate = new XmlFormate();
            }
            return xmlFormate;
        }
        public bool IsRightFormate(string Data)
        {
            try
            {
                xmlDoc = XDocument.Parse(Data);
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
            if (xmlDoc is null)
            {
                throw new NullReferenceException("Document object is null");
            }
            return xmlDoc;
        }
    }
}