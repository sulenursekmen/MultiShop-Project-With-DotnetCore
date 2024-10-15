using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values=await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            //return values;

            var responseMessage = await _httpClient.GetAsync("categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdForUpdateCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
