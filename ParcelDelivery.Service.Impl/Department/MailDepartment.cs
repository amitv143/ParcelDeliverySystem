using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public class MailDepartment : Department, IParcelDeliveryService
    {
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Weight <= 1;
        }
        public void ParcelProcess(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Processed the parcel.");
        }
    }
}
