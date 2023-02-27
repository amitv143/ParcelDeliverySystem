using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System;

namespace ParcelDelivery.Service.Impl
{
    public class HeavyDepartment:Department,IParcelDeliveryService
    {
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Weight > 10;
        }

        public void ParcelProcess(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }

        public ParcelDeliveryResult Send(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
