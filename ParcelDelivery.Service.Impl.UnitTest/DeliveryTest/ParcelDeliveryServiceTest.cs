using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ParcelDelivery.Model.Payload.Request;

namespace ParcelDelivery.Service.Impl.UnitTest.DeliveryTest
{
    [TestClass]
    public class ParcelDeliveryServiceTest
    {
        private ParcelDeliveryService parcelDeliveryService;


        [TestInitialize]
        public void TestInitialize()
        {
            parcelDeliveryService = new ParcelDeliveryService();
        }


        [TestMethod]
        public void WhenInvokedWithValidRequest_ShouldReturnSuccessResponse()
        {
            //Arrange
            Organization organization = new Organization();
            Parcel parcel = new Parcel();
            organization.Departments = new List<Department>() { };

            //Act
            var result = parcelDeliveryService.Send(organization, parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }

        [TestMethod]
        public void WhenInvokedWithWeight_ShouldReturnSuccessResponse()
        {
            //Arrange
            Organization organization = new Organization();
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 100;

            organization.Departments = new List<Department>() {  new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                     };

            //Act
            var result = parcelDeliveryService.Send(organization, parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }


        [TestMethod]
        public void WhenInvokedWithValueGreaterThan100_ShouldReturnSuccessResponse()
        {
            //Arrange
            Organization organization = new Organization();
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 10001;

            organization.Departments = new List<Department>() {  new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                     };

            //Act
            var result = parcelDeliveryService.Send(organization, parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }
    }
}
