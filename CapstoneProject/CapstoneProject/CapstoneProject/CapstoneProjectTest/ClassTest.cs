using CapstoneProject.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CapstoneProject.UnitTests.Entities
{
    public class ClassTest
    {
        [Test]
        public void Class_ShouldHaveProperties()
        {
            // Arrange
            var classUnderTest = new Class();

            // Act
            classUnderTest.ClassId = 1;
            classUnderTest.ClassName = "Yoga";
            classUnderTest.ClassPrice = 20;
            classUnderTest.InstructorId = 2;
            classUnderTest.Clients = new List<Client>();
            classUnderTest.Instructors = new List<Instructor>();

            // Assert
            Assert.AreEqual(1, classUnderTest.ClassId);
            Assert.AreEqual("Yoga", classUnderTest.ClassName);
            Assert.AreEqual(20, classUnderTest.ClassPrice);
            Assert.AreEqual(2, classUnderTest.InstructorId);
            Assert.IsNotNull(classUnderTest.Clients);
            Assert.IsNotNull(classUnderTest.Instructors);
        }
    }
}