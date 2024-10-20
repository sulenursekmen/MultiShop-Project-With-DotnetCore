using MultiShop.DtoLayer.OrderDtos.AddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDto>> GetAllAddressAsync();
        Task CreateAddressAsync(CreateAddressDto createAddressDto);
        Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        Task DeleteAddressAsync(string id);
        Task<GetByIdAddressDto> GetByIdAddressAsync(string id);
        Task<UpdateAddressDto> GetByIdForUpdateAddressAsync(string id);
    }
}
