using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.UserId = command.UserId;
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.Phone = command.Phone;
            values.Country = command.Country;
            values.District = command.District;
            values.City = command.City;
            values.AddressLine1 = command.AddressLine1;
            values.AddressLine2 = command.AddressLine2;
            values.Description = command.Description;
            values.ZipCode = command.ZipCode;
            await _repository.UpdateAsync(values);
        }
    }
}
