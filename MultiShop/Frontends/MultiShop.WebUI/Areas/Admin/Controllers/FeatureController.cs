using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;
        public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService featureService)
        {
            _httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureViewbagIndex();
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            FeatureViewbagCreate();
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewbagUpdate();
            var values = await _featureService.GetByIdForUpdateFeatureAsync(id);
            return View(values);
        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
        #region void Viewbags
        void FeatureViewbagIndex()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan ";
            ViewBag.v3 = "Öne Çıkan Listesi";
        }
        void FeatureViewbagCreate()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan ";
            ViewBag.v3 = "Yeni Öne Çıkan  Girişi";
        }
        void FeatureViewbagUpdate()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan ";
            ViewBag.v3 = "Yeni Öne Çıkan Güncelleme";
        }
        #endregion
    }
}
