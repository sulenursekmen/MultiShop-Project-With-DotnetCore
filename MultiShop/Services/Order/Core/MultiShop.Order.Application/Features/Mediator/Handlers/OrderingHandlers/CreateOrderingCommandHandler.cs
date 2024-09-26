using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{

    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand, Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });

            // Unit.Value, MediatR ile uyumlu bir dönüş tipi
            return Unit.Value;
        }
    }

    //    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    //    {
    //        private readonly IRepository<Ordering> _repository;

    //        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
    //        {
    //            _repository = repository;
    //        }

    //        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    //        {
    //            await _repository.CreateAsync(new Ordering
    //            {
    //                OrderDate = request.OrderDate,
    //                TotalPrice = request.TotalPrice,
    //                UserId = request.UserId,

    //            });
    //        }

    //        Task<Unit> IRequestHandler<CreateOrderingCommand, Unit>.Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
}
