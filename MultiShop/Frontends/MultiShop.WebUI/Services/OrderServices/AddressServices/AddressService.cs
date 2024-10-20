using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public class AddressService:IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateAddressDto>("addresses", createAddressDto);
        }

        public async Task DeleteAddressAsync(string id)
        {
            await _httpClient.DeleteAsync("addresses?id=" + id);
        }

        public async Task<List<ResultAddressDto>> GetAllAddressAsync()
        {
            var responseMessage = await _httpClient.GetAsync("addresses");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData); ; ;
            return values;
        }

        public async Task<GetByIdAddressDto> GetByIdAddressAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("addresses/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdAddressDto>();
            return values;
        }

        public async Task<UpdateAddressDto> GetByIdForUpdateAddressAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("addresses/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAddressDto>();
            return values;
        }

        public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAddressDto>("addresses", updateAddressDto);
        }
    }
}
