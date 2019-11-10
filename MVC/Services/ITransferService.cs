using MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
   public interface ITransferService
    {
        Task transfer(TransferDTO transferDTO) ;
    }
}
