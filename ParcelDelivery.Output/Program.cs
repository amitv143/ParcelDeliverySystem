using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Model.Utility;
using ParcelDelivery.Service.Impl;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ParcelDelivery.Output
{
    internal class Program
    {
        private const string XmlFilePath = @"Files/Container.xml";
      
        static void Main(string[] args)
        {
            var parcelsContainer = XMLParseUtility.ParseXml<ParcelsContainer>(XmlFilePath);
            Console.WriteLine($"************** {parcelsContainer.Parcels.Count} Parcels is ready to process **************");
            var defaultOrganization = CreateOrganization();

            Process(defaultOrganization, parcelsContainer);

            Console.WriteLine();
            Console.WriteLine("*************************     Done!    *************************");
        }

        private static void Process(Organization organization, ParcelsContainer container)
        {
            var service = new ParcelDeliveryService();

            foreach (var parcel in container.Parcels)
            {
                service.Send(organization, parcel);

                Thread.Sleep(3000);//Just for simulation
            }
        }
        private static Organization CreateOrganization()
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
