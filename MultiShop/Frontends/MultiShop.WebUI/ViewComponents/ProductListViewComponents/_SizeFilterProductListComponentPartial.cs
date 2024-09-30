using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _SizeFilterProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
