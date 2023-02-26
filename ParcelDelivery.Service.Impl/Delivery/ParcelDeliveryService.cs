using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDelivery.Service.Impl
{
    public class ParcelDeliveryService 
    {

         public ParcelDeliveryService()
        {

        }
        public ParcelDeliveryResult Send(Organization organization, Parcel parcel)
        {
            var result = new ParcelDeliveryResult();

            var signers = organization.GetSignerDepartments();

            var processors = organization.GetProcessorDepartments();


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

        public static Organization CreateOrganization()
        {
            return new Organization
            {
                Departments = new List<Department>
                {
                    new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                }
            };
        }
    }
}
