using LawOffice05.Core.Models.Case;
using LawOffice05.Core.Models.Case.Enumerations;
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
            var aModelWithCaseDiscrition = new AddCaseViewModel()
            {
                CaseDescriptionNames = GetCaseDescriptions()
            };

            return View(aModelWithCaseDiscrition);
        }

        [HttpPost]
        public IActionResult AddCase(AddCaseViewModel caseModel)
        {
            if (!ModelState.IsValid)
            {
                caseModel.CaseDescriptionNames = GetCaseDescriptions();

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

        [HttpGet]
        public IActionResult AllCases([FromQuery]AllCasesQueryModel query)
        {
            var caseQuery = data.Cases.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CaseDescription))
            {
                caseQuery = caseQuery.Where(c => c.CaseDescription == query.CaseDescription);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                caseQuery = caseQuery.Where(c =>
                    (c.ClientFirstName + " " + c.ClientMiddleName + " " + c.ClientFamiliName)
                    .ToLower().Contains(query.SearchTerm.ToLower()));
            }

            caseQuery = query.Sorting switch
            {
                CaseSorting.CaseNumber => caseQuery.OrderBy(c => c.InsideCaseNumber),
                CaseSorting.CaseDiscriprion => caseQuery.OrderBy(c => c.CaseDescription),
                CaseSorting.ClientName => caseQuery.OrderBy(c => c.ClientFirstName),
                _ => caseQuery.OrderBy(c => c.InsideCaseNumber)
            };

            var allCases = caseQuery
                .Skip((query.CurrentPage - 1) * AllCasesQueryModel.CasesPerPage)
                .Take(AllCasesQueryModel.CasesPerPage)
                .Select(c => new AllCasesViewModel()
                {
                    CaseId = c.Id,
                    InsideCaseNumber = c.InsideCaseNumber,
                    InsideCaseName = c.InsideCaseName,
                    ClientName = c.ClientFirstName + " " + c.ClientFamiliName,
                    CaseDescription = c.CaseDescription
                })
                .ToList();

            var CaseDescriptionList = this.data
                .Cases
                .Select(c => c.CaseDescription)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            var totalCases = caseQuery.Count();

            query.TotalCases = totalCases;
            query.Cases = allCases;
            query.CaseDescriptions = CaseDescriptionList;

            return View(query);
        }

        public IActionResult ClientInfo(int id)
        {
            var theCase = GetCaseById(id);

            var theClientInfo = new ClientInfoViewModel()
            {
                ClientFullName = theCase.ClientFirstName + " " + theCase.ClientMiddleName + " " + theCase.ClientFamiliName,
                ClientEGN = theCase.ClientID,
                ClientAddress = theCase.ClientAdrress
            };

            return View(theClientInfo);
        }

        private Case GetCaseById(int id)
        {
            var theCase = data.Cases.FirstOrDefault(c => c.Id == id);

            return theCase;
        }

        private IEnumerable<CaseDescriptionViewModel> GetCaseDescriptions()
        {
            var allCaseDescriptionNames = data.OrderProblemTypes
                .Select(c => new CaseDescriptionViewModel()
                {
                    Id = c.Id,
                    ProblemType = c.ProblemType
                })
                .ToList();

            return allCaseDescriptionNames;
        }
    }
}
