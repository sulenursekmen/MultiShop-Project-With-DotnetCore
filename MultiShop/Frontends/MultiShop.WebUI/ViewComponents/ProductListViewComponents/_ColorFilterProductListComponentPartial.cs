using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ColorFilterProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
