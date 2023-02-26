using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ParcelDelivery.Model.Payload.Request
{
    public class Parcel
    {
        public Parcel()
        {

        }
        public Parcel(double weight, double value)
        {
            Weight = weight;
            Value = value;
        }

        public Company Sender { get; set; }
        [XmlElement("Receipient")]
        public Receipient Recipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
