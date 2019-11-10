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

namespace IoC
{
   public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {          
            //Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain banking commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<BankingDbContext>();

        }
    }
}
