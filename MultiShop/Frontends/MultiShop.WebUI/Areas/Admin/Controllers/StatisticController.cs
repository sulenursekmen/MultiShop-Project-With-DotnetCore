using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Admin Paneli";
            ViewBag.v2 = "İstatistikler";
            ViewBag.v3 = "İstatistik";

            var brandCountValue=await _catalogStatisticService.GetBrandCount();
            var categoryCountValue=await _catalogStatisticService.GetCategoryCount();
            var maxPriceProductNameValue=await _catalogStatisticService.GetMaxPriceProductName();
            var minPriceProductNameValue=await _catalogStatisticService.GetMinPriceProductName();
            var productAvgPriceValue=await _catalogStatisticService.GetProductAvgPrice();
            var productCountValue=await _catalogStatisticService.GetProductCount();

            ViewBag.brandCount = brandCountValue;
            ViewBag.categoryCount = categoryCountValue;
            ViewBag.maxPriceProductName = maxPriceProductNameValue;
            ViewBag.minPriceProductName = minPriceProductNameValue;
            ViewBag.productAvgPrice = productAvgPriceValue;
            ViewBag.productCount = productCountValue;

            var userCountValue=await _userStatisticService.GetUserCount();
            ViewBag.userCount = userCountValue;

            var totalCommentCountValue=await _commentStatisticService.GetTotalCommentCount();
            var passiveCommentCountValue=await _commentStatisticService.GetPassiveCommentCount();
            var activeCommentCountValue=await _commentStatisticService.GetActiveCommentCount();

            ViewBag.totalCommentCount= totalCommentCountValue;
            ViewBag.passiveCommentCount = passiveCommentCountValue;
            ViewBag.activeCommentCount = activeCommentCountValue;

            var messageCountValue=await _messageStatisticService.GetTotalMessageCount();
            ViewBag.messageCount = messageCountValue;

            var discountCountValue=await _discountStatisticService.GetDiscountCouponCountAsync();
            ViewBag.discountCount = discountCountValue;

            return View();
        }
    }
}

