using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;

namespace ParcelDelivery.Service.Impl
{

    public class AddDepartment : Department, IParcelDeliveryService
    {
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Weight > 50;
        }

        public void ParcelProcess(Parcel parcel)
        {

        }

        public ParcelDeliveryResult Send(Parcel parcel)
        {
            throw new System.NotImplementedException();
        }
    }
}
