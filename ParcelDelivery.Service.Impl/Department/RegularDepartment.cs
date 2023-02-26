using ParcelDelivery.Model.Payload.Request;
using System;
namespace ParcelDelivery.Service.Impl
{
    public class RegularDepartment : Department,IParcelDeliveryService
    {
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Weight > 1 && parcel.Weight <= 10;
        }

        public void ParcelProcess(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }
    }
}
