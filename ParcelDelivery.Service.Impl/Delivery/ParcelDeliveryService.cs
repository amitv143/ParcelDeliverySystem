using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelDelivery.Service.Impl
{
    public class ParcelDeliveryService : IParcelDeliveryService
    {
        private readonly IOrganization _organization;

         public ParcelDeliveryService(IOrganization organization)
        {
             _organization= organization;
        }

        public void ParcelProcess(Parcel parcel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// It will distribute the department based on business rules.
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        public ParcelDeliveryResult Send(Parcel parcel)
        {
            _organization.Departments = CreateOrganization();
            var result = new ParcelDeliveryResult();
            var signers = _organization.GetSignerDepartments();
            var processors = _organization.GetProcessorDepartments();

            var signerDepartment = signers.FirstOrDefault(d => d.TrackingInfo(parcel));
            if (signerDepartment != null)
            {
                ((IParcelSigOff)signerDepartment).SignOff(parcel);

                result.ParcelDepartmentsFlow.Add(signerDepartment);
            }

            var processorDepartment = processors.FirstOrDefault(d => d.TrackingInfo(parcel));
            if (processorDepartment != null)
            {
                ((IParcelDeliveryService)processorDepartment).ParcelProcess(parcel);

                result.ParcelDepartmentsFlow.Add(processorDepartment);
            }

            result.IsSent = true;

            return result;
        }

        /// <summary>
        /// List of departments
        /// </summary>
        /// <returns></returns>
        private List<Department> CreateOrganization()
        {
            return new List<Department>
                {
                    new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                };
        }
    }
}
