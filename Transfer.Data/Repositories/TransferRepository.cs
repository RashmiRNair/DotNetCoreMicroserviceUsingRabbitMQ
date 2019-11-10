
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TransferLog transferLog)
        {
            _dbContext.Add(transferLog);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _dbContext.TransferLogs;
        }
    }
}
