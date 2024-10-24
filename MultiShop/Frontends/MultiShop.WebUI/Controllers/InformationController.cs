using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
