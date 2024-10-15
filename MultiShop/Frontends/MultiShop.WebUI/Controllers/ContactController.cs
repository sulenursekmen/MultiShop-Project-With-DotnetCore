using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
