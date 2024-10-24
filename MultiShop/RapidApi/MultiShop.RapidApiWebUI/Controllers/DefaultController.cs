using Microsoft.AspNetCore.Mvc;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
