using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserCardUserLayoutViewComponentPartial:ViewComponent
    {
        private readonly IUserService _userService;

        public _UserCardUserLayoutViewComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        
        
       {
            var userViewModel = await _userService.GetUserInfo();
            var userDto = ConvertToDto(userViewModel); // Dönüşüm yap
            return View(userDto); // Dönüştürülmüş DTO'yu View'e gönder
        }

        public UserDetailDto ConvertToDto(UserDetailViewModel viewModel)
        {
            return new UserDetailDto
            {
                Id = viewModel.Id,
                Username = viewModel.Username,
                Email = viewModel.Email,
                Name = viewModel.Name,
                Surname = viewModel.Surname
            };
        }

    }
}
