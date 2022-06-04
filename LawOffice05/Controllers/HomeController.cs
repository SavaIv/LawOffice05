using LawOffice05.Core.Models.Home;
using LawOffice05.Core.Services.Statistics;
using LawOffice05.Infrastructure.Data;
using LawOffice05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LawOffice05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext data;
        private readonly IStatisticsService statistics;

        public HomeController(
            ILogger<HomeController> _logger,
            ApplicationDbContext _data,
            IStatisticsService statistics)
        {

            //logger = _logger;
            data = _data;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {           
            var totalStatistics = this.statistics.Total();

            var theStatistics = new IndexViewModel()
            {
                TotalActiveOrders = totalStatistics.TotalActiveOrders,
                TotalActiveCases = totalStatistics.TotalActiveCases
            };

            return View(theStatistics);
        }

        public IActionResult Info()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}