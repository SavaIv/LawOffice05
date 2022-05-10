using LawOffice05.Core.Models.Api.Statistics;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public StatisticsApiController(ApplicationDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var statistics = new StatisticsResponseModel()
            {
                TotalActiveCases = data.Cases.Count(),
                TotalActiveOrders = data.Orders.Count()
            };

            return statistics;
        }
    }
}
