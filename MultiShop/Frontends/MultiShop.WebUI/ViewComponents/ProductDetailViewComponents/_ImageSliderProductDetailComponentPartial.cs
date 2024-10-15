using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ImageSliderProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;
        public _ImageSliderProductDetailComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            if (values != null)
            {
                return View(values);
            }
            return View(new GetByIdProductImageDto());
        }

    }
}