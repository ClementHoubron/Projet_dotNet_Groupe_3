using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class TransactionBackgroundService : BackgroundService
{
    private readonly HttpClient _httpClient;

    public TransactionBackgroundService()
    {
        _httpClient = new HttpClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"[INFO] Service en cours d'exécution : {DateTimeOffset.Now}");

            try
            {
                await CallApiEndpointAsync("generate-random-file-transaction", "Génération du fichier de transactions", true);
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                await CallApiEndpointAsync("read-file-transactions", "Lecture et enregistrement des transactions", true);
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                await CallApiEndpointAsync("generate-file-verif-transaction", "Génération du fichier des transactions validées");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERREUR] {ex.Message}");
            }

            Console.WriteLine("[INFO] En attente 10 minutes avant la prochaine exécution...");
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }

    private async Task CallApiEndpointAsync(string route, string actionDescription, bool isPost = false)
    {
        string url = $"https://localhost:7260/api/transactions/{route}";
        Console.WriteLine($"[INFO] {actionDescription} en cours...");

        try
        {
            HttpResponseMessage response;

            if (isPost)
            {
                response = await _httpClient.PostAsync(url, null);
            }
            else
            {
                response = await _httpClient.GetAsync(url);
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[INFO] {actionDescription} terminée avec succès.");
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[ERREUR] {actionDescription} a échoué. Statut : {response.StatusCode}, Message : {errorMessage}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERREUR] Problème lors de {actionDescription} : {ex.Message}");
        }
    }

    public override void Dispose()
    {
        _httpClient.Dispose();
        base.Dispose();
    }
}
