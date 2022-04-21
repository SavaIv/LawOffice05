using LawOffice05.Core.Models.Orders;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext data;

        public OrderController(ApplicationDbContext _data)
        {
            data = _data;
        }

        public IActionResult Add()
        {
            var problemNames = new AddOrderFormModel
            {
                ProblemTypeNames = GetProblemTypesName()
            };
            
            return View(problemNames);
        }

        [HttpPost]
        public IActionResult Add(AddOrderFormModel order)
        {
            return View();
        }

        private IEnumerable<OredrProblemTypeViewModel> GetProblemTypesName()
        {
            var result = data.OrderProblemTypes
                .Select(x => new OredrProblemTypeViewModel
                {
                    Id = x.Id,
                    ProblemTypeName = x.ProblemType
                })
                .ToList();

            return result;
        }
    }
}
