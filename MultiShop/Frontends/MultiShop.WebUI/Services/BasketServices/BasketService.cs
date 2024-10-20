using MultiShop.DtoLayer.BasketDtos;
using Newtonsoft.Json;


namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();

            // Eğer values null ise yeni bir sepet oluşturuluyor
            if (values == null)
            {
                values = new BasketTotalDto();
                values.BasketItems = new List<BasketItemDto>();
            }

            // Eğer sepet varsa ve ürün zaten eklenmemişse sepete ekle
            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                // Eğer ürün zaten sepette varsa, isteğe göre miktarı artırma gibi işlemler yapılabilir.
                // Ancak burada values sıfırlanmamalı.
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                existingItem.Quantity += basketItemDto.Quantity;  // Mevcut miktara ekleyin
            }

            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            //var responseMessage = await _httpClient.GetAsync("baskets");
            //var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            //return values;
            var responseMessage = await _httpClient.GetAsync("baskets");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BasketTotalDto>(jsonData);
            return values;
        }

        public async Task<BasketTotalDto> GetByUserIdBasket(string userId)
        {
            var responseMessage = await _httpClient.GetAsync("baskets?userId="+userId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BasketTotalDto>(jsonData);
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {

            var responseMessage = await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}



