using LawOffice05.Core.Models.Case;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class CaseController : Controller
    {
        private readonly ApplicationDbContext data;

        public CaseController(ApplicationDbContext _data)
        {
            data = _data;
        }


        public IActionResult AddCase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCase(AddCaseViewModel caseModel)
        {
            if (!ModelState.IsValid)
            {
                return View(caseModel);
            }

            var newCase = new Case()
            {
                InsideCaseNumber = caseModel.InsideCaseNumber,
                InsideCaseName = caseModel.InsideCaseName,
                ClientFirstName = caseModel.ClientFirstName,
                ClientMiddleName = caseModel.ClientMiddleName,
                ClientFamiliName = caseModel.ClientFamiliName,
                ClientAdrress = caseModel.ClientAdrress,
                ClientID = caseModel.ClientID,
                CaseDescription = caseModel.CaseDescription
            };

            data.Cases.Add(newCase);
            data.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
