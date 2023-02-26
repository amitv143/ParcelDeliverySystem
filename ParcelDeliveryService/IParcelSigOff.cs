using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service
{
    public interface IParcelSigOff
    {
        /// <summary>
        /// Pacrcel signOff
        /// </summary>
        /// <param name="parcel"></param>
        void SignOff(Parcel parcel);
    }
}
