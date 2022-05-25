using LawOffice05.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext data;

        public StatisticsService(ApplicationDbContext _data)
        {
            data = _data;
        }

        public StatisticsServiceModel Total()
        {
            var totalOrders = this.data.Orders.Count();
            var totalCases = this.data.Cases.Count();

            return new StatisticsServiceModel()
            {
                TotalActiveCases = totalCases,
                TotalActiveOrders = totalOrders
            };
                
        }
    }
}
