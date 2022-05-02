using LawOffice05.Core.Models.Seniors;
using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LawOffice05.Controllers
{
    public class SeniorsController : Controller
    {
        private readonly ApplicationDbContext data;

        public SeniorsController(ApplicationDbContext _data)
        {
            data = _data;
        }

        [Authorize]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeSeniorViewModel senior)
        {            
            var userIdAlreadyDealer = UserIsDealer();

            if (userIdAlreadyDealer)
            {
                return BadRequest();
            }

            // if modelStare is not OK
            if (!ModelState.IsValid)
            {
                return View(senior);
            }

            // if modelState is OK
            var aNewSeniour = new Senior
            {
                Position = senior.Position,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            this.data.Seniors.Add(aNewSeniour);
            this.data.SaveChanges();

            return RedirectToAction("AllCases", "Case");
        }

        private bool UserIsDealer()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIsSenior = data.Seniors.Any(s => s.UserId == userId);

            return userIsSenior;
        }
    }
}
