using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var userValue=await _userService.GetUserInfo();
            //ViewBag.SenderName=userValue.Name + " " + userValue.Surname;
            var values=await _messageService.GetInboxMessageAsync(userValue.Id);
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var userValue = await _userService.GetUserInfo();
            var values = await _messageService.GetSendBoxMessageAsync(userValue.Id);
            return View(values);
        }
    }
}
