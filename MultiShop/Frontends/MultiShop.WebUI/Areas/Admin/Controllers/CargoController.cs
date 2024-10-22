using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        #region CargoCompany

        [HttpGet]
        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            ViewBag.v1 = "Kargo İşlemleri";
            ViewBag.v2 = "Kargo Şirketi";
            ViewBag.v3 = "Yeni Kargo Şirketi Girişi";
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(string id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(string id)
        {
            ViewBag.v1 = "Kargo İşlemleri";
            ViewBag.v2 = "Kargo Şirketi";
            ViewBag.v3 = "Kargo Şirketi Güncelleme";
            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(value);
        }
        [Route("UpdateCargoCompany/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        #endregion
    }
}
