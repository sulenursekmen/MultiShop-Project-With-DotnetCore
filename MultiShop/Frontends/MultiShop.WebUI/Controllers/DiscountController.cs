using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;


        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var discountRateValue = await _discountService.GetDiscountCouponRate(code);
            var basketValues = await _basketService.GetBasket();
            var taxPrice = basketValues.TotalPrice / 100 * 20;
            var totalPriceWithTax = basketValues.TotalPrice + taxPrice;
            var discountAmount = basketValues.TotalPrice / 100 * discountRateValue;
            var finalPriceAfterDiscount = totalPriceWithTax - discountAmount;


            ViewBag.finalPriceAfterDiscount = finalPriceAfterDiscount;
            ViewBag.discountRateValue=discountRateValue;
            ViewBag.discountAmount=discountAmount;

            return RedirectToAction("Index", "ShoppingCart", new { code=code, discountRateValue = discountRateValue });
        }



    }
}
