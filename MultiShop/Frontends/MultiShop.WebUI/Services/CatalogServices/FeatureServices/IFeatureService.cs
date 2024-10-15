using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdForUpdateFeatureAsync(string id);
    }
}
