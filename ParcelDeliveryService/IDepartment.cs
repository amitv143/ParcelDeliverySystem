using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service
{
    public interface IDepartment
    {
        bool TrackingInfo(Parcel parcel);
        void ShowParcelInfo(Parcel parcel);
    }
}
