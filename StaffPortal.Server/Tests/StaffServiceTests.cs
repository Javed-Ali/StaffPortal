using Moq;
using StaffPortal.Server.BusinessLogic.Services;
using StaffPortal.Server.Data;
using Xunit;

namespace StaffPortal.Server.Tests
{
    public class StaffServiceTests
    {
        private readonly IStaffService _staffService;
        public StaffServiceTests()
        {
            var mockRepository = new Mock<IStaffRepository>();
            _staffService = new StaffService(mockRepository.Object);
        }

        [Fact]
        public void CalculateSalary_ShouldReturnCorrectSalary()
        {
            // Arrange
            var qualificationLevel = 8;
            var yearsOfExperience = 10;

            // Act
            var salary = _staffService.CalculateSalary(qualificationLevel, yearsOfExperience);

            // Assert
            Assert.Equal(160000m, salary);
        }
    }
}

