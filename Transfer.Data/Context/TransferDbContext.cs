using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Domain.Models;

namespace Transfer.Data.Context
{
   public class TransferDbContext: DbContext
    {

        public TransferDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
