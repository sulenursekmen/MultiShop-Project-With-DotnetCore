using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMongoCollection<ProductImage> _mongoCollection;

        public ProductImageController(IHttpClientFactory httpClientFactory, IMongoCollection<ProductImage> mongoCollection)
        {
            _httpClientFactory = httpClientFactory;
            _mongoCollection = mongoCollection;
        }

        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Güncelleme";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            if (updateProductImageDto.ProductImageId == null)
            {
                var newProductImage = new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(), // Unique ID üretiyoruz
                    ProductId = updateProductImageDto.ProductId,
                    Image1=updateProductImageDto.Image1,
                    Image2=updateProductImageDto.Image2,
                    Image3=updateProductImageDto.Image3,
                };

                await _mongoCollection.InsertOneAsync(newProductImage);
                var postResponse = await client.PostAsync("https://localhost:7070/api/ProductImages", stringContent);
                if (postResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
            }
            else
            {
                var putResponse = await client.PutAsync("https://localhost:7070/api/ProductImages", stringContent);
                if (putResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
            }
            return View();
        }



    }
}
