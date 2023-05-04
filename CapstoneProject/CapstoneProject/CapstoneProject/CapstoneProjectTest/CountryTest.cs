using CapstoneProject.Entities;
using NUnit.Framework;

namespace CapstoneProject.Tests
{
    [TestFixture]
    public class CountryTest
    {
        [Test]
        public void CountryProperties_SetAndGetCorrectly()
        {
            // Arrange
            var country = new Country();

            // Act
            country.CountryId = 1;
            country.CountryName = "Canada";

            // Assert
            Assert.AreEqual(1, country.CountryId);
            Assert.AreEqual("Canada", country.CountryName);
        }
    }
}