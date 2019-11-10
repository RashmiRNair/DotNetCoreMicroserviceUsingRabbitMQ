using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;
        
        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.SourceAccount, accountTransfer.DestinationAccount, accountTransfer.AmountToTransfer);
            _eventBus.SendCommand(createTransferCommand);

        }
    }
}
