using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public abstract class Department : IDepartment
    {
        public abstract bool TrackingInfo(Parcel parcel);
        public void ShowParcelInfo(Parcel parcel)
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************************");
            Console.WriteLine($"From: {parcel.Sender.Name}, To: {parcel.Recipient.Name}");
            Console.WriteLine();
        }
    }

}
