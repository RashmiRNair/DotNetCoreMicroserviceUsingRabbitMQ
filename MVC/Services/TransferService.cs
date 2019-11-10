using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVC.Models.DTO;
using Newtonsoft.Json;

namespace MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient httpClient)
        {
            _apiClient = httpClient;
        }
        public async  Task transfer(TransferDTO transferDTO)
        {
            var uri = "http://localhost:5000/api/banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
