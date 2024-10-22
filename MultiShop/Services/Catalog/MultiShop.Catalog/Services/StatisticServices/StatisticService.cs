using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productColllection;
        private readonly IMongoCollection<Category> _categoryColllection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productColllection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryColllection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public long GetBrandCount()
        {
            return _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public long GetCategoryCount()
        {
            return _categoryColllection.CountDocuments(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice); // En yüksek fiyat için azalan sıralama
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductId");

            var product = await _productColllection.Find(filter)
                                                   .Sort(sort)
                                                   .Project(projection)
                                                   .FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }


        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice); // En düşük fiyat için artan sıralama
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductId");

            var product = await _productColllection.Find(filter)
                                                   .Sort(sort)
                                                   .Project(projection)
                                                   .FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }


        public async Task<decimal> GetProductAvgPrice()
        {
            var products = await _productColllection.Find(FilterDefinition<Product>.Empty).ToListAsync();

            var prices = products
                .Select(p => p.ProductPrice) 
                .Where(price => price >= 0);

            if (prices.Any())
            {
                return prices.Average(); 
            }
            return 0m;
        }

        public long GetProductCount()
        {
            return _productColllection.CountDocuments(FilterDefinition<Product>.Empty); 
        }
    }
}
