using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountsController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _OfferDiscountService.GetAllOfferDiscountsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await _OfferDiscountService.GetGetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("The OfferDiscount has been added successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("The OfferDiscount has been deleted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("The OfferDiscount has been updated successfully");
        }
    }
}
