using LawOffice05.Core.Models.Orders;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                ProblemTypeNames = this.GetProblemTypesName()
            };
            
            return View(problemNames);
        }

        [HttpPost]
        public IActionResult Add(AddOrderFormModel order)
        {
            if(!this.data.OrderProblemTypes.Any(pt => pt.ProblemType == order.ProblemType))
            {
                // add error in the ModelState (by hand)
                this.ModelState.AddModelError(nameof(order.ProblemType), "Problem Type does not exist.");
            }


            if (!ModelState.IsValid)
            {                
                order.ProblemTypeNames = GetProblemTypesName();
                
                return View(order);
            }

            var newOrder = new Order
            {
                FeedBack = "n.a",
                StatusOfTheOrder = "pending",
                ProblemDescription = order.ProblemDescription,                
                ProblemType = order.ProblemType,
                TypeOfAnswer = order.TypeOfAnswer,
                UrgencyType = order.UrgencyType                
            };

            data.Orders.Add(newOrder);
            data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<OredrProblemTypeViewModel> GetProblemTypesName()
        {
            var result = this.data.OrderProblemTypes
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
