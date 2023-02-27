using ParcelDelivery.Model.Payload.Request;
using System.Threading.Tasks;

namespace ParcelDelivery.Service.Impl.Contract
{
    public interface IParcelDeliveryService
    {
        /// <summary>
        /// Parcel process
        /// </summary>
        /// <param name="parcel"></param>
        void ParcelProcess(Parcel parcel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        ParcelDeliveryResult Send(Parcel parcel);
    }
}
