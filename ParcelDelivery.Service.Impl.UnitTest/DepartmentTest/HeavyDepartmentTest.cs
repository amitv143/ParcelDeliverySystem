using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelDelivery.Model.Payload.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Service.Impl.UnitTest.DepartmentTest
{
    [TestClass]
    internal class HeavyDepartmentTest
    {
        private HeavyDepartment heavyDepartment;

        [TestInitialize]
        public void TestInitialize()
        {
            heavyDepartment = new HeavyDepartment();
        }

        [TestMethod]
        public void WhenInvokedWithTrackingInfo_ShouldreturnSuccess()
        {
            //Arrange
            Parcel parcel = new Parcel() { Value = 10, Weight = 10, Sender = new Company() };

            //Act
            var result = heavyDepartment.TrackingInfo(parcel);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
