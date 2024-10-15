using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("Contacts?id=" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData); ; ;
            return values;
        }
        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        public async Task<UpdateContactDto> GetByIdForUpdateContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateContactDto>();
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contacts", updateContactDto);
        }
    }
}
