using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderingService _orderingService;

        public MyOrderController(IUserService userService, IOrderingService orderingService)
        {
            _userService = userService;
            _orderingService = orderingService;
        }
        public async Task<IActionResult> MyOrderList()
        {
            var userInfo = await _userService.GetUserInfo();
            var values = await _orderingService.GetOrderingByUserId(userInfo.Id);
            return View(values);
         
        }

        //public async Task<IActionResult> MyOrderList()
        //{
        //    var userInfo = await _userService.GetUserInfo();

        //    if (userInfo != null)
        //    {
        //        var name = userInfo.Name;
        //        var surname = userInfo.Surname;
        //        var fullName = name + " " + surname;
        //        ViewBag.FullName = fullName;
        //        return View(userInfo);
        //    }
        //    return View();

        //}
    }
}

