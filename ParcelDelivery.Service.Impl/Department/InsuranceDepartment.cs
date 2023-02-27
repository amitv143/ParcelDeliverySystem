using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public class InsuranceDepartment : Department, IParcelSigOff
    {
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Value > 1000;
        }

        public void SignOff(Parcel parcel)
        {
            ShowParcelInfo(parcel);
            Console.WriteLine($"{this.GetType().Name} Signed off the parcel.");
        }
    }
}
