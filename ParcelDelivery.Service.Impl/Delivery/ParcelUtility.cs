using ParcelDelivery.Service.Impl.Contract;
using System.IO;
using System.Xml.Serialization;

namespace ParcelDelivery.Service.Impl
{
    public class ParcelUtility : IParcelUtility
    {
        /// <summary>
        /// It will parse the xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public T ParseXml<T>(string xmlFilePath)
        {
            if (File.Exists(xmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(T));
                var t = default(T);

                using (var streamReader = File.OpenText(xmlFilePath))
                {
                    t = (T)serializer.Deserialize(streamReader);
                }

                return t;
            }
            else
                throw new FileNotFoundException("This file was not found.");
        }
    }
}
