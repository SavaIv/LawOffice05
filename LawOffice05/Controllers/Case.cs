using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class Case : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
