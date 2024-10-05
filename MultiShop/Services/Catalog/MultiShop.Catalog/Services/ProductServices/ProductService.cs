using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productColllection;
        private readonly IMongoCollection<Category> _categoryColllection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client =new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productColllection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryColllection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values=_mapper.Map<Product>(createProductDto);
            await _productColllection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productColllection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productColllection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetGetByIdProductAsync(string id)
        {
            var values=await _productColllection.Find<Product>(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var products = await _productColllection.Find<Product>(x => true).ToListAsync();
            var categories = await _categoryColllection.Find<Category>(x => true).ToListAsync();

            var result = _mapper.Map<List<ResultProductsWithCategoryDto>>(products);

            foreach (var item in result)
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == item.CategoryId);
                item.CategoryName = category != null ? category.CategoryName : "Category Not Found";
            }
            return result;
        }


        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            return _productColllection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
