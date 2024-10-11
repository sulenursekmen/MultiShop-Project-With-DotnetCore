using System.Security.Claims;

namespace MultiShop.WebUI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
                if (_contextAccessor.HttpContext?.User?.Identity.IsAuthenticated == true)
                {
                    return _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                }

                return null;
            }
        }
    }
}
