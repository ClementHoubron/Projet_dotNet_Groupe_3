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
        Task<decimal> ConvertToEuro(string devise);

    }
    public class TauxDeChangeService : ITauxDeChangeService

    {
        private readonly HttpClient _httpClient;

        public TauxDeChangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> ConvertToEuro(string devise)
        {
            if (devise == "EUR") return 1.0m;

            var response = await _httpClient.GetStreamAsync($"https://api.exchangerate-api.com/v4/latest/{devise}");
            var rates = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            var rate = Convert.ToDecimal(((JsonElement)rates["rates"]).GetProperty("EUR").GetDecimal());

            return rate;
        }
    }
}
