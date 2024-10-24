using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
#region using
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.OrderServices.AddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Settings;

#endregion

public static class HttpClientExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, ServiceApiSettings values)
    {
        #region Identity Service
        services.AddHttpClient<IUserService, UserService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
        #endregion

        #region Catalog Microservice
        AddCatalogHttpClients(services, values);
        #endregion

        #region Comment Microservice
        AddCommentHttpClients(services, values);
        #endregion

        #region Basket Microservice
        AddBasketHttpClient(services, values);
        #endregion

        #region Discount Microservice
        AddDiscountHttpClients(services, values);
        #endregion

        #region Order Microservice
        AddOrderHttpClients(services, values);
        #endregion

        #region Message Microservice
        AddMessageHttpClients(services, values);
        #endregion

        #region Cargo Microservice
        AddCargoHttpClients(services, values);
        #endregion

        return services;
    }

    private static void AddCatalogHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICategoryService, CategoryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductService, ProductService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IFeatureService, FeatureService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IBrandService, BrandService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IAboutService, AboutService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IContactService, ContactService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
    }

    private static void AddCommentHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<IUserCommentService, UserCommentService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ICommentStatisticService, CommentStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }

    private static void AddBasketHttpClient(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<IBasketService, BasketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }

    private static void AddDiscountHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<IDiscountService, DiscountService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IDiscountStatisticService, DiscountStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }

    private static void AddOrderHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<IAddressService, AddressService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IOrderingService, OrderingService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }

    private static void AddMessageHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<IMessageService, MessageService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }

    private static void AddCargoHttpClients(IServiceCollection services, ServiceApiSettings values)
    {
        services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }
}
