using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _AdditionalInfoProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _AdditionalInfoProductDetailComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var response = await _productDetailService.GetByIdForUpdateProductDetailAsync(id);

            if (response !=null)
            {
                return View(response);
            }
            var emptyDto = new UpdateProductDetailDto { ProductId = id };
            return View(emptyDto);
        }
    }
}
