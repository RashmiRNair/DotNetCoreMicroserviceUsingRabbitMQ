using Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Application.Interfaces;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _eventBus;
        private readonly ITransferRepository _transferRepository;

        public TransferService(ITransferRepository transferRepository,IEventBus eventBus )
        {
            _transferRepository = transferRepository;
            _eventBus = eventBus;
        }


        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
