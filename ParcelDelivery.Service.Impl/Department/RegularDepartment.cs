using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System;
namespace ParcelDelivery.Service.Impl
{
    public class RegularDepartment : Department,IParcelDeliveryService
    {
        /// <summary>
        /// It will track the parcel info.
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        public override bool TrackingInfo(Parcel parcel)
        {
            return parcel.Weight > 1 && parcel.Weight <= 10;
        }

        /// <summary>
        /// It will process the parcel.
        /// </summary>
        /// <param name="parcel"></param>
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
