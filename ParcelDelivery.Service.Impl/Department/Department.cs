using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public abstract class Department
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
