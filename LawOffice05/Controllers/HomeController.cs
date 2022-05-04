using LawOffice05.Core.Models.Home;
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

        public HomeController(ILogger<HomeController> _logger, ApplicationDbContext _data)
        {
            logger = _logger;
            data = _data;
        }

        public IActionResult Index()
        {
            var totalOrders = this.data.Orders.Count();
            var totalCases = this.data.Cases.Count();

            var statistics = new IndexViewModel()
            {
                TotalActiveOrders = totalOrders,
                TotalActiveCases = totalCases
            };

            return View(statistics);
        }

        public IActionResult Info()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}