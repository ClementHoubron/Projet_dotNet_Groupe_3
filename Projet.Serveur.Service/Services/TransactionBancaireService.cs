using System.Text.Json;
using System.Transactions;
using Projet.Serveur.Data.Repositories;
using Projet.Serveur.Data.Entities;
using System.Timers;

namespace Projet.Serveur.Service.Services
{
    public interface ITransactionService
    {
        void ProcessTransaction(TransactionDto transactionDto);
        void ExportTransactions();
        void ExportAnomalies();
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void ProcessTransaction(TransactionDto transactionDto)
        {
            var transaction = new TransactionBancaire
            {
                NumeroCarte = transactionDto.NumeroCarte,
                Montant = transactionDto.Montant,
                TypeOperation = transactionDto.TypeOperation,
                DateOperation = transactionDto.DateOperation,
                Devise = transactionDto.Devise,
                EstValide = LuhnValidateur.Validate(transactionDto.NumeroCarte)
            };

            _repository.AddTransaction(transaction);
        }

        public void ExportTransactions()
        {
            var transactions = _repository.GetValidTransactions();
            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("validated_transactions.json", json);
        }

        public void ExportAnomalies()
        {
            var anomalies = _repository.GetAnomalies();
            string json = JsonSerializer.Serialize(anomalies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("anomalies.json", json);
        }
    }
    public class ScheduledExportService
    {
        private readonly ITransactionService _transactionService;
        private readonly System.Timers.Timer _timer;

        public ScheduledExportService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            _timer = new System.Timers.Timer(86400000);
            _timer.Elapsed += RunExport;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void RunExport(object sender, ElapsedEventArgs e)
        {
            _transactionService.ExportTransactions();
            _transactionService.ExportAnomalies();
            Console.WriteLine("Export JSON quotidien effectué à : " + DateTime.Now);
        }
    }
}
