using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryViewbagIndex();
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            CategoryViewbagCreateCategory();
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewbagUpdateCategory();
            var values= await _categoryService.GetByIdForUpdateCategoryAsync(id);
            return View(values);
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }

        #region void
        void CategoryViewbagIndex()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
        }
        void CategoryViewbagUpdateCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme";
        }
        void CategoryViewbagCreateCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
        }

        #endregion

    }
}
