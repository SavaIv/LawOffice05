using LawOffice05.Core.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Controllers
{
    public class OrderController : Controller
    {
        //private readonly IOrderService service;

        //public OrderController(IOrderService _service)
        //{
        //    service = _service;
        //}

        //public IActionResult ConfirmOrderFeedbackChanged()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> ManageOrders()
        //{
        //    var orders = await service.GetOrders();

        //    return View(orders);
        //}

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddOrderFormModel order)
        {
            return View();
        }

        public IActionResult ManageOrders()
        {
            return View();
        }

        //public async Task<IActionResult> FeedBack(Guid Id)
        //{
        //    var model = await service.GetOrderForFeedback(Id);

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> FeedBack(OrderFeedbackViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    service.UpdateOrderFeedback(model);


        //    return RedirectToAction(nameof(ConfirmOrderFeedbackChanged));
        //}
    }
}
