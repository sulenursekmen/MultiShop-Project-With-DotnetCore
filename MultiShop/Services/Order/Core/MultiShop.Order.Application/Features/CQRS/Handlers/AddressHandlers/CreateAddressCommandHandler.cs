using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {  
                UserId = createAddressCommand.UserId,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone= createAddressCommand.Phone,
                Country = createAddressCommand.Country,
                District = createAddressCommand.District,
                City = createAddressCommand.City,
                AddressLine1 = createAddressCommand.AddressLine1,
                AddressLine2 = createAddressCommand.AddressLine2,
                Description = createAddressCommand.Description,
                ZipCode = createAddressCommand.ZipCode,
            });
        }
    }
}