using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public class Organization 
    {
        public IList<Department> Departments { get; set; }

        public IList<Department> GetSignerDepartments()
        {
            return Departments.Where(x => x is IParcelSigOff).ToList();

        }

        public IList<Department> GetProcessorDepartments()
        {
            return Departments.Where(x => x is IParcelDeliveryService).ToList();
        }

    }
}
