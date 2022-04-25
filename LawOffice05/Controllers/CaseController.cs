using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
