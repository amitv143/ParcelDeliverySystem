using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

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
