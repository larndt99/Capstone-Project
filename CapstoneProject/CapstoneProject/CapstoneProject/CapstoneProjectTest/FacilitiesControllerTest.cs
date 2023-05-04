using CapstoneProject.Controllers;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.DataAccess;
using CapstoneProject.Entities;
using Xunit;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectTest
{
    public class FacilitiesControllerTest
    {
        private static List<Facility> GetTestFacilityList()
        {
            return new List<Facility>()
            {
                new Facility
                {
                    FacilityId = 1,
                    Name = "Facility 1",
                    Address = "101 Facility Road"
                },
                new Facility
                {
                    FacilityId = 2,
                    Name = "Facility 2",
                    Address = "102 Facility Road"
                }
            };
        }

        [Fact]
        public async Task TestFacilitiesIndex()
        {
            var ClassDbContextMock = new Mock<ClassDbContext>();
            ClassDbContextMock.Setup<DbSet<Facility>>(x => x.Facility)
                .ReturnsDbSet(GetTestFacilityList());
            //Act
            FacilitiesController facilityController = new(ClassDbContextMock.Object);
            var actResult = (await facilityController.Index()) as ViewResult;
            Assert.NotNull(actResult);
            Assert.Equal(2, (actResult.Model as List<Facility>).Count);
        }

    }
}