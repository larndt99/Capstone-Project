using CapstoneProject.Entities;
using NUnit.Framework;

namespace CapstoneProject.UnitTests.Entities
{
    public class ClientTest
    {
        [Test]
        public void Client_PropertiesShouldHaveValues()
        {
            // Arrange
            var clientUnderTest = new Client
            {
                ClientId = 1,
                ClientName = "John Smith",
                ClientAddress = "123 Main St",
                ClientPhoneNumber = 1234567890,
                ClientPostalCode = "M1M1M1",
                ClassId = 2
            };

            // Assert
            Assert.AreEqual(1, clientUnderTest.ClientId);
            Assert.AreEqual("John Smith", clientUnderTest.ClientName);
            Assert.AreEqual("123 Main St", clientUnderTest.ClientAddress);
            Assert.AreEqual(1234567890, clientUnderTest.ClientPhoneNumber);
            Assert.AreEqual("M1M1M1", clientUnderTest.ClientPostalCode);
            Assert.AreEqual(2, clientUnderTest.ClassId);
            Assert.IsNull(clientUnderTest.Class);
        }

        [Test]
        public void Client_PhoneNumber_ShouldHaveTenDigits()
        {
            // Arrange
            var clientUnderTest = new Client
            {
                ClientPhoneNumber = 1234567890
            };

            // Act
            var validationResults = new System.ComponentModel.DataAnnotations.ValidationResult[1];
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(clientUnderTest);
            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(clientUnderTest, context, validationResults, true);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Client_PhoneNumber_ShouldNotHaveLessThanTenDigits()
        {
            // Arrange
            var clientUnderTest = new Client
            {
                ClientPhoneNumber = 123456789
            };

            // Act
            var validationResults = new System.ComponentModel.DataAnnotations.ValidationResult[1];
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(clientUnderTest);
            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(clientUnderTest, context, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}