using AutoMapper;
using AutoMapper.QueryableExtensions;
using LawOffice05.Core.Models.Orders;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace LawOffice05.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public OrderController(ApplicationDbContext _data, IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        [Authorize]
        public IActionResult Add()
        {          
            var problemNames = new AddOrderFormModel
            {
                ProblemTypeNames = this.GetProblemTypesName()
            };
            
            return View(problemNames);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddOrderFormModel order)
        {
            // целта е да се предпазим от това, някой да подпъхне нещо зловредно
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
                UrgencyType = order.UrgencyType,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            data.Orders.Add(newOrder);
            data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var ordres = data.Orders       
                .OrderByDescending(o => o.Id)
                .ProjectTo<OrderListingViewModel>(mapper.ConfigurationProvider)                     
                .ToList();        
            
            return View(ordres);
        }

        public IActionResult FeedBack(int Id)
        {
            var theOrder = GetOrderByOrderId(Id);

            var theModel = new OrderFeedbackViewModel()
            {
                OrderId = Id,
                FeedBack = theOrder.FeedBack
            };

            return View(theModel);
        }

        [HttpPost]
        public IActionResult FeedBack(OrderFeedbackViewModel feedBackModel)
        {
            if (!ModelState.IsValid)
            {
                // подаваме същия модел  
                return View(feedBackModel);
            }

            var orderToBeModified = data.Orders.First(o => o.Id == feedBackModel.OrderId);
            orderToBeModified.FeedBack = feedBackModel.FeedBack;

            data.SaveChanges();

            return RedirectToAction("All", "Order");
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

        private Order GetOrderByOrderId(int Id)
        {
            var resultOrder = data.Orders.First(o => o.Id == Id);
            
            return resultOrder;
        }
    }
}
