using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class TransactionExportService : BackgroundService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionExportService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextRun = now.Date.AddDays(1).AddHours(0);
            var delay = nextRun - now;

            await Task.Delay(delay, stoppingToken);

            _transactionRepository.GenererFichierTransactions();
            Console.WriteLine($"Fichier JSON généré à {DateTime.Now}");
        }
    }
}
