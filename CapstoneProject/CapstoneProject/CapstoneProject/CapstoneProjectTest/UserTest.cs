using CapstoneProject.Entities;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace CapstoneProject.Tests.Entities
{
    public class UserTest
    {
        [Fact]
        public void User_Inherits_IdentityUser()
        {
            // Arrange
            var user = new User();

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUser>(user);
        }

        // TODO: add more unit tests for any custom properties or methods in the User class
    }
}