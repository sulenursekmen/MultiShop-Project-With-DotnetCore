using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
        Task<UpdateAboutDto> GetByIdForUpdateAboutAsync(string id);
    }
}
