using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Model.Payload.Request
{
    public class Address
    {
        [JsonProperty("street", Order = 1)]
        public string Street { get; set; }
        [JsonProperty("housenumber", Order = 2)]
        public int HouseNumber { get; set; }
        [JsonProperty("postalcode", Order = 1)]
        public string PostalCode { get; set; }
        [JsonProperty("city", Order = 1)]
        public string City { get; set; }
    }
}
