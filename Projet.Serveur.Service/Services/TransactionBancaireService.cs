using System.Text.Json;
using System.Transactions;
using Projet.Serveur.Data.Repositories;
using Projet.Serveur.Data.Entities;
using System.Timers;

namespace Projet.Serveur.Service.Services
{
    public interface ITransactionService
    {
        Task ProcessTransaction(TransactionDto transactionDto);
        Task<IEnumerable<TransactionBancaire>> GetValidTransactionsAsync();
        
        void ExportTransactions();
        void ExportAnomalies();
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly ITauxDeChangeService _tauxDeChangeService;


        public TransactionService(ITransactionRepository repository, ITauxDeChangeService tauxDeChangeService)
        {
            _repository = repository;
            _tauxDeChangeService = tauxDeChangeService;
        }

        public async Task ProcessTransaction(TransactionDto transactionDto)
        {
            bool isValidCard = LuhnValidateur.Validate(transactionDto.NumeroCarte);
            bool isValidOperation = new HashSet<string> { "Retrait DAB", "Facture CB", "Dépôt Guichet" }
                                        .Contains(transactionDto.TypeOperation);
            bool isValid = isValidCard && isValidOperation;
            var transaction = new TransactionBancaire
            {
                NumeroCarte = transactionDto.NumeroCarte,
                Montant = transactionDto.Montant,
                TypeOperation = transactionDto.TypeOperation,
                DateOperation = transactionDto.DateOperation,
                Devise = transactionDto.Devise,
                EstValide = isValid,
            };

            _repository.AddTransaction(transaction);
        }
        public async Task<IEnumerable<TransactionBancaire>> GetValidTransactionsAsync()
        {
            return _repository.GetValidTransactions();
        }

        public async void ExportTransactions()
        {
            var transactions = _repository.GetValidTransactions().Select(async t => new
            {
                t.NumeroCarte,
                t.Montant,
                t.TypeOperation,
                t.DateOperation,
                t.Devise,
                ExchangeRate = t.Devise != "EUR" ? await _tauxDeChangeService.GetTauxDeChangeAsync(t.Devise) : 1.0m
            }).Select(t => t.Result);

            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("validated_transactions.json", json);
        }
       

        public void ExportAnomalies()
        {
            var anomalies = _repository.GetAnomalies().Select(t => new
            {
                t.NumeroCarte,
                t.Montant,
                t.TypeOperation,
                t.DateOperation,
                t.Devise
            });

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
            Console.WriteLine("Export JSON quotidien effectué à : " + DateTime.Now);
        }
    }
}
