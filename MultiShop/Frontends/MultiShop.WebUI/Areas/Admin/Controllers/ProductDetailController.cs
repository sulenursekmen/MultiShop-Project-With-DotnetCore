using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("AddOrUpdateProductDetail/{id}")]
        public async Task<IActionResult> AddOrUpdateProductDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Detayları Ekleme/Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/ProductDetails/ProducDetailsByProductId?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(value);
            }
            var emptyDto = new UpdateProductDetailDto { ProductId = id };
            return View(emptyDto);
        }
        [Route("AddOrUpdateProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateProductDetail(UpdateProductDetailDto updateProductDetailDto,CreateProductDetailDto createProductDetailDto  , string id)
        {
            updateProductDetailDto.ProductId = id;
            createProductDetailDto.ProductId = id;
            if (!ModelState.IsValid || string.IsNullOrEmpty(updateProductDetailDto.ProductDetailId))
            {
                var client1 = _httpClientFactory.CreateClient();
                var jsonData1 = JsonConvert.SerializeObject(createProductDetailDto);
                StringContent content = new StringContent(jsonData1, Encoding.UTF8, "application/json");
                var response1 = await client1.PostAsync("https://localhost:7070/api/ProductDetails", content);
                if (response1.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
                return View(createProductDetailDto);
            }
 
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/ProductDetails/", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View(updateProductDetailDto);
        }
    }
}
