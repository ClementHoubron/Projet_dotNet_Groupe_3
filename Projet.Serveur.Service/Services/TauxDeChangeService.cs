using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projet.Serveur.Service.Services
{
    public interface ITauxDeChangeService
    {
        Task<decimal> GetTauxDeChangeAsync(string devise);
    }

    public class ExchangeRateService : ITauxDeChangeService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetTauxDeChangeAsync(string devise)
        {
            if (devise == "EUR") return 1m;

            var response = await _httpClient.GetStringAsync($"https://api.exchangerate-api.com/v4/latest/EUR");
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            var rates = JsonSerializer.Deserialize<Dictionary<string, decimal>>(data["rates"].ToString());
            return rates.ContainsKey(devise) ? rates[devise] : 1m;
        }
    }
}
