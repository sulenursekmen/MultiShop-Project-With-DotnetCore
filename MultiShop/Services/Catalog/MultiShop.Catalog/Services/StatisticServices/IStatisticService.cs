namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        long GetCategoryCount();
        long GetProductCount();
        long GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
