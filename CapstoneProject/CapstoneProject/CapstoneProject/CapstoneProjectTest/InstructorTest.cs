using CapstoneProject.Entities;
using NUnit.Framework;

namespace CapstoneProject.Tests.Entities
{
    public class InstructorTest
    {
        [Test]
        public void InstructorPropertiesSetCorrectly()
        {
            // Arrange
            var instructor = new Instructor
            {
                InstructorId = 1,
                InstructorName = "John Doe",
                InstructorAddress = "123 Main St",
                InstructorPostalCode = "ABC123",
                InstructorPhoneNumber = 1234567890,
                ClassId = 2,
                Class = new Class()
            };

            // Act

            // Assert
            Assert.AreEqual(1, instructor.InstructorId);
            Assert.AreEqual("John Doe", instructor.InstructorName);
            Assert.AreEqual("123 Main St", instructor.InstructorAddress);
            Assert.AreEqual("ABC123", instructor.InstructorPostalCode);
            Assert.AreEqual(1234567890, instructor.InstructorPhoneNumber);
            Assert.AreEqual(2, instructor.ClassId);
            Assert.IsNotNull(instructor.Class);
        }
    }
}
This test checks that the properties of the Instructor class can be set correctly and that the Class property is not null when assigned.





