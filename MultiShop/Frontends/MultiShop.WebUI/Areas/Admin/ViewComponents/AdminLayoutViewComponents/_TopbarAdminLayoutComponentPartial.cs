using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.User.Controllers;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _TopbarAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly ICommentStatisticService _commentStatisticService;

        public _TopbarAdminLayoutComponentPartial(IMessageStatisticService messageStatisticService, IUserService userService, IMessageService messageService, IUserCommentService userCommentService, ICommentStatisticService commentStatisticService)
        {
            _messageStatisticService = messageStatisticService;
            _userService = userService;
            _messageService = messageService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int messageCountByReceviverId = await _messageStatisticService.GetTotalMessageCountByReceiverId(user.Id);
            ViewBag.messageCountByReceviverId= messageCountByReceviverId;
            ViewBag.FullName=user.Name + " " + user.Surname;

            var totalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            ViewBag.totalCommentCount= totalCommentCount;   

            var values = await _messageService.GetInboxMessageAsync(user.Id);
            return View(values);
        }
    }
}
