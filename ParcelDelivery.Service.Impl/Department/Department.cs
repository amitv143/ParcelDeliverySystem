using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public  abstract class Department : IDepartment
    {
        public abstract bool TrackingInfo(Parcel parcel);
        public void ShowParcelInfo(Parcel parcel)
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************************");
            Console.WriteLine($"Parcel Weight: {parcel.Weight}, Parcel Value: {parcel.Value}");
            Console.WriteLine();
        }
    }

}
