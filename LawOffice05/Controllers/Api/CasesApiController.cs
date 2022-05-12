using LawOffice05.Core.Models.Api.Cases;
using LawOffice05.Core.Models.Enumerations;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LawOffice05.Controllers.Api
{
    [ApiController]
    [Route("api/cases")]
    public class CasesApiController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public CasesApiController(ApplicationDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        // нещо не е ОК - не ми се плучава
        public AllCasesApiResponseModel AllCases([FromQuery] AllCasesApiRequestModel query)
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
                .Skip((query.CurrentPage - 1) * query.CasesPerPage)
                .Take(query.CasesPerPage)
                .Select(c => new CaseResponseModel()
                {
                    CaseId = c.Id,
                    InsideCaseNumber = c.InsideCaseNumber,
                    InsideCaseName = c.InsideCaseName,
                    ClientName = c.ClientFirstName + " " + c.ClientFamiliName,
                    CaseDescription = c.CaseDescription,
                    SupervisorName = c.Senior.User.FirstName + " " + c.Senior.User.LastName
                })
                .ToList();

            return new AllCasesApiResponseModel()
            {
                TotalCases = allCases.Count,
                CurrentPage = query.CurrentPage,
                Cases = allCases
            };
        }






        // долните редове са с учебна цел - някакви семпли тестове за това що е АПИ
        //[HttpGet]
        //public IEnumerable GetCases()
        //{
        //    return data.Cases.ToList();
        //}

        //[Route("{id}")]
        //public IActionResult GetDetails(int id)
        //{
        //    //return data.Cases.Find(id);

        //    var aCase = data.Cases.Find(id);

        //    if(aCase == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(aCase);
        //}

        //[HttpPost]
        //public IActionResult SaveCase (Case aCase)
        //{
        //    //data.Cases.Add(aCase);

        //    return Ok();
        //}

    }
}
