using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;



namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
           
            return View();
        }


        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signUpDto)
        {
            signUpDto.Username = "sullens";
            signUpDto.Password = "141215aA*";
            await _identityService.SignIn(signUpDto);
            return RedirectToAction("Index", "User");
        }
    }
}
