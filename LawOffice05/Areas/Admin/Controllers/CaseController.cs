using LawOffice05.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Areas.Admin.Controllers
{   
    public class CaseController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
