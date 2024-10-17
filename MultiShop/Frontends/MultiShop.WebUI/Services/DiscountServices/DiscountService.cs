using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/GetCodeDetailByCode?code="+code);
            var values=await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/GetDiscountCouponCountRate?code=" + code);
            var discountResponse = await responseMessage.Content.ReadFromJsonAsync<DiscountCouponRateResponse>();
            return discountResponse?.Rate ?? 0; 
        }
    }
}
