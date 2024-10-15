using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService)
        {
            _httpClientFactory = httpClientFactory;
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewbagIndex();
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewbagCreate();
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }


        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewbagUpdate();
            var values = await _featureSliderService.GetByIdForUpdateFeatureSliderAsync(id);
            return View(values);
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        #region void Viewbags
        void FeatureSliderViewbagIndex()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Slider";
            ViewBag.v3 = "Öne Çıkan Slider Listesi";
        }
        void FeatureSliderViewbagCreate()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Slider";
            ViewBag.v3 = "Yeni Öne Çıkan Slider Girişi";
        }
        void FeatureSliderViewbagUpdate()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Slider";
            ViewBag.v3 = "Yeni Öne Çıkan Slider Güncelleme";
        }
        #endregion
    }
}
