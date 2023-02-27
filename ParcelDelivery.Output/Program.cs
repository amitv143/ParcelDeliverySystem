using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service;
using ParcelDelivery.Service.Impl;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

namespace ParcelDelivery.Output
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddSingleton<Executor, Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IParcelUtility, ParcelUtility>();
        }
    }
/// <summary>
/// it is executor class to excute the buisness logic
/// </summary>
    public class Executor
    {
        private readonly IParcelUtility  _parcelUtility;
        private const string XmlFilePath = @"Files/Container.xml";

        public Executor(IParcelUtility parcelUtility)
        {
            _parcelUtility = parcelUtility;
        }

        public void Execute()
        {
            var parcelsContainer = _parcelUtility.ParseXml<ParcelsContainer>(XmlFilePath);
            Console.WriteLine($"-------------{parcelsContainer.Parcels.Count} Parcels is ready to process -----------");

            var defaultOrganization = ParcelUtility.CreateOrganization();
            Process(defaultOrganization, parcelsContainer);

            Console.WriteLine();
            Console.WriteLine("----------------- Done! ------------------------");
        }
        private static void Process(Organization organization, ParcelsContainer container)
        {
            var service = new ParcelDeliveryService();

            foreach (var parcel in container.Parcels)
            {
                service.Send(organization, parcel);

                Thread.Sleep(3000);
            }
        }
    }
}
