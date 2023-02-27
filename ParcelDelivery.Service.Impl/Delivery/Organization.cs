using ParcelDelivery.Service.Impl.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParcelDelivery.Service.Impl
{
    public class Organization  : IOrganization
    {
        /// <summary>
        /// List od departments
        /// </summary>
        public  IList<Department> Departments { get; set; }

        /// <summary>
        /// It is get signer departments
        /// </summary>
        /// <returns></returns>
        /// 
        public IList<Department> GetSignerDepartments()
        {
            return Departments.Where(x => x is IParcelSigOff).ToList();

        }

        /// <summary>
        /// It is get processor departments
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetProcessorDepartments()
        {
            return Departments.Where(x => x is IParcelDeliveryService).ToList();
        }

    }
}
