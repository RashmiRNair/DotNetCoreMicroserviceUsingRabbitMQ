using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Application.Models
{
    public class AccountTransfer
    {
        public int SourceAccount { get; set; }
        public int DestinationAccount { get; set; }
        public decimal AmountToTransfer { get; set; }
    }
}
