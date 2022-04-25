using LawOffice05.Core.Models.Tests;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult Exo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Exo(TestOne test)
        {
            return View();
        }


        public IActionResult SeedDb()
        {



            return View();
        }


    }
}
