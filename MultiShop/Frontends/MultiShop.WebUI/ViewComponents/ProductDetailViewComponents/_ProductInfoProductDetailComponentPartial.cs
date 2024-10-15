using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductInfoProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductInfoProductDetailComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetByIdForUpdateProductAsync(id);
            return View(values);
        }
    }
}
