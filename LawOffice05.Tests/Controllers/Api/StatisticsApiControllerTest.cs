using LawOffice05.Controllers.Api;
using LawOffice05.Tests.Moqs;
using Xunit;

namespace LawOffice05.Tests.Controllers.Api
{
    public class StatisticsApiControllerTest
    {
        [Fact]
        public void GetStatisticsShouldReturnTotalStatistics()
        {
            // Arrange
            var statisticsController = new StatisticsApiController(StatisticsDataMoq.Instance);

            // Act
            var result = statisticsController.GetStatistics();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(5, result.TotalCars);
            //Assert.Equal(10, result.TotalRents);
            //Assert.Equal(15, result.TotalUsers);
        }
    }
}
