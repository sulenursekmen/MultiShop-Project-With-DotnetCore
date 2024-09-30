using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _PriceFilterProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
