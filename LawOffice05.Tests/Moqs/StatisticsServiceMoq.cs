using LawOffice05.Core.Services.Statistics;
using Moq;

namespace LawOffice05.Tests.Moqs
{
    public static class StatisticsServiceMoq
    {
        public static IStatisticsService Instance
        {
            get
            {
                var statisticsServiceMock = new Mock<IStatisticsService>();

                statisticsServiceMock
                    .Setup(s => s.Total())
                    .Returns(new StatisticsServiceModel
                    {
                          TotalActiveCases = 1,
                          TotalActiveOrders = 1
                    });

                return statisticsServiceMock.Object;
            }
        }
    }
}
