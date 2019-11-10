using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repositories;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;

using Banking.Domain.Interfaces;
using Core.Bus;
using MediatR;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Application.Interfaces;
using Transfer.Application.Services;
using Transfer.Data.Context;
using Transfer.Data.Repositories;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;

namespace IoC
{
   public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {          
            //Domain bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<TransferEventHandler>();

            //Domain banking commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application services
            services.AddTransient<IAccountService, AccountService>();

            //Transfer Service
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();

            //Handler 
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

        }
    }
}
