using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service
{
    public interface IParcelSigOff
    {
        void SignOff(Parcel parcel);
    }
}
