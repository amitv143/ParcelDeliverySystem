using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl;
using ParcelDelivery.Service.Impl.Contract;
using System;
using System.Threading;

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
            services.AddScoped<IParcelUtility, ParcelUtility>();
            services.AddScoped<IOrganization, Organization>();
            services.AddScoped<IParcelDeliveryService, ParcelDeliveryService>();
        }
    }
    /// <summary>
    /// it is executor class to excute the buisness logic
    /// </summary>
    public class Executor
    {
        private readonly IParcelUtility  _parcelUtility;
        private readonly IOrganization _organization;
        private readonly IParcelDeliveryService _parcelDeliveryService;
        private const string XmlFilePath = @"Files/Container.xml";

        public Executor(IParcelUtility parcelUtility, IOrganization organization, IParcelDeliveryService parcelDeliveryService )
        {
            _parcelUtility = parcelUtility;
            _organization = organization;
            _parcelDeliveryService = parcelDeliveryService;
        }

        public void Execute()
        {
            var parcelsContainer = _parcelUtility.ParseXml<ParcelsContainer>(XmlFilePath);
            Console.WriteLine($"-------------{parcelsContainer.Parcels.Count} Parcels is ready to process -----------");
            Process(parcelsContainer);
            Console.WriteLine();
            Console.WriteLine("----------------- Done! ------------------------");
        }
        private void Process(ParcelsContainer container)
        {

            foreach (var parcel in container.Parcels)
            {
                _parcelDeliveryService.Send(parcel);

                Thread.Sleep(3000);//just for simulation
            }
        }
    }
}
