using System;
using System.Net;

namespace ParcelDelivery.Model.Exception
{
    public class ParcelDeliveryException 
    {
        public HttpStatusCode StatusCode { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public ParcelDeliveryException(HttpStatusCode statusCode, int errorNumber, string errorMessage) : base()
        {
            StatusCode = statusCode;
            ErrorCode = errorNumber;
            ErrorMessage = errorMessage;
        }
    }
}
