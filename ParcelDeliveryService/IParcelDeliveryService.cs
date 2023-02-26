using ParcelDelivery.Model.Payload.Request;
using System.Threading.Tasks;

namespace ParcelDelivery.Service
{
    public interface IParcelDeliveryService
    {
      void ParcelProcess(Parcel parcel);
    }
}
