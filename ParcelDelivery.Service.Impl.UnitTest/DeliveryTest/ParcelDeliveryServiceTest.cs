using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParcelDelivery.Model.Payload.Request;
using ParcelDelivery.Service.Impl.Contract;
using System.Collections.Generic;
using System.Linq;

namespace ParcelDelivery.Service.Impl.UnitTest.DeliveryTest
{
    [TestClass]
    public class ParcelDeliveryServiceTest
    {
        private ParcelDeliveryService parcelDeliveryService;
        private readonly Mock<IOrganization> _mockMrganization =new Mock<IOrganization>() ;
        private readonly  List<Department> departmentList =
           new List<Department>
               {
                    new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
               };


        [TestInitialize]
        public void TestInitialize()
        {
           
            parcelDeliveryService = new ParcelDeliveryService(_mockMrganization.Object);

            _mockMrganization.Setup(X => X.Departments).Returns(departmentList);
        }

        [TestMethod]
        public void WhenInvokedWithWeightLessThan1_ShouldReturnMailDept()
        {
            //Arrange
          
            Parcel parcel = new Parcel();
            parcel.Weight = 0.2;
            parcel.Value = 100;
            _mockMrganization.Setup(x => x.GetSignerDepartments()).Returns(new List<Department>());
            _mockMrganization.Setup(x => x.GetProcessorDepartments()).Returns(departmentList);
            //Act
            var result = parcelDeliveryService.Send( parcel);
            var dept = result.ParcelDepartmentsFlow.FirstOrDefault().ToString();
            //Assert
            Assert.IsTrue(dept.Split('.').Contains("MailDepartment"));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }

        [TestMethod]
        public void WhenInvokedWithWeightUpTo10_ShouldReturRegularDept()
        {
            //Arrange
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 100;

            _mockMrganization.Setup(x => x.GetSignerDepartments()).Returns(new List<Department>());
            _mockMrganization.Setup(x => x.GetProcessorDepartments()).Returns(departmentList);

            //Act
            var result = parcelDeliveryService.Send(parcel);

            var dept = result.ParcelDepartmentsFlow.FirstOrDefault().ToString();
            //Assert
            Assert.IsTrue(dept.Split('.').Contains("RegularDepartment"));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }

        [TestMethod]
        public void WhenInvokedWithWeightGreaterThan10_ShouldReturHeavyDept()
        {
            //Arrange
            Parcel parcel = new Parcel();
            parcel.Weight = 200;
            parcel.Value = 100;

            _mockMrganization.Setup(x => x.GetSignerDepartments()).Returns(new List<Department>());
            _mockMrganization.Setup(x => x.GetProcessorDepartments()).Returns(departmentList);

            //Act
            var result = parcelDeliveryService.Send(parcel);

            var dept = result.ParcelDepartmentsFlow.FirstOrDefault().ToString();
            //Assert
            Assert.IsTrue(dept.Split('.').Contains("HeavyDepartment"));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }


        [TestMethod]
        public void WhenInvokedWithValueGreaterThan100_ShouldReturnInsuranceDept()
        {
            //Arrange
    
            Parcel parcel = new Parcel();
            parcel.Weight = 2;
            parcel.Value = 10001;

            _mockMrganization.Setup(x => x.GetSignerDepartments()).Returns(departmentList);
            _mockMrganization.Setup(x => x.GetProcessorDepartments()).Returns(new List<Department>());
            //Act
            var result = parcelDeliveryService.Send(parcel);
            var dept = result.ParcelDepartmentsFlow.FirstOrDefault().ToString();
            //Assert
            Assert.IsTrue(dept.Split('.').Contains("InsuranceDepartment"));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSent);
        }
    }
}
