using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ParcelDelivery.Model.Payload.Request
{
    [XmlRoot("Container")]
    public class ParcelsContainer
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        [XmlArray("parcels")]
        public List<Parcel> Parcels { get; set; }
    }
}
