using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            if (xmlFormate == null)
            {
                xmlFormate = new XmlFormate();
                return xmlFormate;
            }
            else
            {
                return xmlFormate;
            }
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
            if (IsRightFormate(Data))
            {
                if (xmlDoc is not null)
                {
                    return xmlDoc;
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
