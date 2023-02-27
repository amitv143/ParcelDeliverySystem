using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParcelDelivery.Service.Impl.Contract
{
    public interface IOrganization
    {
        IList<Department> Departments { get; set; }
        IList<Department> GetSignerDepartments();
        IList<Department> GetProcessorDepartments();
    }
}
