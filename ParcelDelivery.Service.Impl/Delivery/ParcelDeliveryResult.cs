using System.Collections.Generic;
namespace ParcelDelivery.Service.Impl
{
    public class ParcelDeliveryResult
    {

        public ParcelDeliveryResult()
        {
            ParcelDepartmentsFlow = new List<Department>();
        }
        public bool IsSent { get; set; }
        public List<Department> ParcelDepartmentsFlow { get; set; }
    }
}
