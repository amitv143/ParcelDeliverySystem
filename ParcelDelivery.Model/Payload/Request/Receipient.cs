using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Model.Payload.Request
{
    public class Receipient
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
