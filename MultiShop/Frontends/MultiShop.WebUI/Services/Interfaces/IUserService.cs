using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
