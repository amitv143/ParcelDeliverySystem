namespace ParcelDelivery.Service
{
    public interface IParcelUtility
    {
        /// <summary>
        /// It is parse the xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        T ParseXml<T>(string xmlFilePath);
    }
}
