﻿using ParcelDelivery.Model.Payload.Request;
using System.Threading.Tasks;

namespace ParcelDelivery.Service
{
    public interface IParcelDeliveryService
    {
        /// <summary>
        /// Parcel process
        /// </summary>
        /// <param name="parcel"></param>
        void ParcelProcess(Parcel parcel);
    }
}
