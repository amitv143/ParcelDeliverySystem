using System.IO;
using System.Xml.Serialization;

namespace ParcelDelivery.Model.Utility
{
    public class XMLParseUtility
    {
        public static T ParseXml<T>(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            var t = default(T);

            using (var streamReader = File.OpenText(xmlFilePath))
            {
                t = (T)serializer.Deserialize(streamReader);
            }

            return t;
        }
    }
}