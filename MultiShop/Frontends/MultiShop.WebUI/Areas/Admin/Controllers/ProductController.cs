using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        #region ctor
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }
        #endregion

        #region ProductList Index
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewbagIndex();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductListWithCategoryViewbag();
            var values= await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }
        #endregion

        #region CreateProduct
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            CreateProductViewbag();

            var values=await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                   }
                                                 ).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {  
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
 
        }

        #endregion

        #region DeleteProduct
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }


        #endregion

        #region UpdateProduct

        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                   }
                                                 ).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues=await _productService.GetByIdForUpdateProductAsync(id);


            return View(productValues);
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }
        #endregion

        #region void Viewbags
        void ProductViewbagIndex()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
        }
        void ProductListWithCategoryViewbag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
        }
        void CreateProductViewbag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Ekleme";
        }
        void UpdateProductViewbag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";
        }
        #endregion
    }
}
