using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IUserCommentService _userCommentService;

        public ProductListController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.productDetailId = id;
           
            return View();
        }
        [HttpGet]
        public PartialViewResult  AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto,string pid)
        {
      
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.Rating = 2;
            var response = await _userCommentService.GetAllCommentAsync();
            return RedirectToAction("Index", "Default");

        }
    }
}
