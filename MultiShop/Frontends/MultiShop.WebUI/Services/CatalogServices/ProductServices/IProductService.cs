using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<UpdateProductDto> GetByIdForUpdateProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryByCategoryIdDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId);
    }
}
