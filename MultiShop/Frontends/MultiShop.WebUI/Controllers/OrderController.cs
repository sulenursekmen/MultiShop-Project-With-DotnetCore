using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Index(CreateAddressDto createAddressDto)
        {    
            var values = await _userService.GetUserInfo();
            createAddressDto.UserId = values.Id;
            await _addressService.CreateAddressAsync(createAddressDto);
            return RedirectToAction("Index","Payment");
        }
    }
}
