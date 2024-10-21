using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
