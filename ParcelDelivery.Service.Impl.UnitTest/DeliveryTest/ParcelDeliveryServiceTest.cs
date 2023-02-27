using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System.Collections.Generic;

namespace ParcelDelivery.Service.Impl.UnitTest.DeliveryTest
{
    [TestClass]
    public class ParcelDeliveryServiceTest
    {
        private ParcelDeliveryService parcelDeliveryService;
        private readonly Mock<IOrganization> _mockMrganization =new Mock<IOrganization>() ;



        [TestInitialize]
        public void TestInitialize()
        {
            parcelDeliveryService = new ParcelDeliveryService(_mockMrganization.Object);

            _mockMrganization.Setup(X => X.Departments).Returns(new List<Department>
                {
                    new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                });
        }

        [TestMethod]
        public void WhenInvokedWithValidRequest_ShouldReturnSuccessResponse()
        {
            //Arrange
          
            Parcel parcel = new Parcel();
            parcel.Weight = 0.2;
            parcel.Value = 100;
            //Act
            var result = parcelDeliveryService.Send( parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }

        [TestMethod]
        public void WhenInvokedWithWeight_ShouldReturnSuccessResponse()
        {
            //Arrange
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 100;

            //Act
            var result = parcelDeliveryService.Send(parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }


        [TestMethod]
        public void WhenInvokedWithValueGreaterThan100_ShouldReturnSuccessResponse()
        {
            //Arrange
    
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 10001;

            //Act
          var result = parcelDeliveryService.Send(parcel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }
    }
}
