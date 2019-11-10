using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.DTO
{
    public class TransferDTO
    {
        public int SourceAccount { get; set; }
        public int DestinationAccount { get; set; }
        public decimal AmountToTransfer { get; set; }   
    }
}
