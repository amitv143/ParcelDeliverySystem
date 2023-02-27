using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelDelivery.Model.Payload.Request;
using System;
using System.IO;
using System.Net;

namespace ParcelDelivery.Service.Impl.UnitTest.DeliveryTest
{
    [TestClass]
    public class ParcelUtilityTest
    {

        private ParcelUtility parcelUtility;

        [TestInitialize]
        public void TestInitialize()
        {
            parcelUtility = new ParcelUtility();
        }


        [TestMethod]
        public void WhenInvokedWithValidXMLPath_ShouldReturnSuccessResponse()
        {
            //Arrange
            string xmlFilePath = @"DeliveryTest/Container.xml";

            //Act
            var result = parcelUtility.ParseXml<ParcelsContainer>(xmlFilePath);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(68465468, result.Id);
            Assert.IsTrue(result.Parcels.Count > 1);
        }

        [TestMethod]
        public void WhenInvokedWithInvalidXMLPath_ShouldReturnNullReferenceException()
        {
            //Arrange
            string xmlFilePath = null;

            var ex = Assert.ThrowsException<FileNotFoundException>(() => parcelUtility.ParseXml<ParcelsContainer>(xmlFilePath));

            //Assert
            Assert.AreEqual("This file was not found.", ex.Message);
        }
    }
}
