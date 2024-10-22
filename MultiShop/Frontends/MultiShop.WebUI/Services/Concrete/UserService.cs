using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/api/users/GetAllUserList");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
            return values;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}
