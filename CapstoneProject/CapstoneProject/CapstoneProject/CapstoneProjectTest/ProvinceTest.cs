using CapstoneProject.Entities;
using Xunit;

namespace CapstoneProject.Tests.Entities
{
    public class ProvinceTest
    {
        [Fact]
        public void Province_ConstructsCorrectly()
        {
            // Arrange
            int expectedId = 1;
            string expectedName = "Ontario";

            // Act
            Province province = new Province
            {
                ProvinceId = expectedId,
                ProvinceName = expectedName
            };

            // Assert
            Assert.Equal(expectedId, province.ProvinceId);
            Assert.Equal(expectedName, province.ProvinceName);
        }
    }
}