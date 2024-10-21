using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
