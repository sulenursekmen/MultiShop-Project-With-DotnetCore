using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ReviewProductDetailComponentPartial : ViewComponent
    {
        private readonly IUserCommentService _userCommentService;

        public _ReviewProductDetailComponentPartial(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.pid = id;
            var values =await _userCommentService.CommentListByProductId(id);
            return View(values);
        }

    }
}
