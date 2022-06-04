using LawOffice05.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice05.Areas.Admin.Controllers
{
    [Area(AdminConstants.AreaName)]
    [Authorize(Roles = WebConstants.AdministratorRoleName)]
    public abstract class AdminController : Controller
    {       
    }
}
