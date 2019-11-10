using Banking.Domain.Commands;
using Banking.Domain.Events;
using Core.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ;
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));
            return Task.FromResult(true);
        }
    }
}
