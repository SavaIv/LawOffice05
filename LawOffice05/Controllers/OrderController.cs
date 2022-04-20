using LawOffice05.Core.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class OrderController : Controller
    {               
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddOrderFormModel test)
        {
            return View();
        }
    }
}
