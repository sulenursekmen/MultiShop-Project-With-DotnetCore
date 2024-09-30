using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _PaginationProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
