using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.DTO;
using MVC.Services;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;
        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDTO transferDTO = new TransferDTO()
            {
                 AmountToTransfer = model.Amount,
                 SourceAccount=model.FromAccount,
                 DestinationAccount=model.ToAccount
            };

            await  _transferService.transfer(transferDTO);
            return View("Index");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
