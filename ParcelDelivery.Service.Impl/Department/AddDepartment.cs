using ParcelDelivery.Model.Payload.Request;

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
    }
}
