using Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRespository;
        

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRespository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRespository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmmount = @event.Amount
            });
           
            return Task.CompletedTask;
        }
    }
}
