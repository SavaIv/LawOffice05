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

        //[HttpGet]
        public IEnumerable GetCases()
        {
            return data.Cases.ToList();
        }

        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            //return data.Cases.Find(id);

            var aCase = data.Cases.Find(id);

            if(aCase == null)
            {
                return NotFound();
            }

            return Ok(aCase);
        }

        [HttpPost]
        public IActionResult SaveCase (Case aCase)
        {
            //data.Cases.Add(aCase);

            return Ok();
        }

    }
}
