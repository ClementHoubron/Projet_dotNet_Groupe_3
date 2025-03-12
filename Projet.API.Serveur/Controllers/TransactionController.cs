using Microsoft.AspNetCore.Mvc;
using Projet.Serveur.Service.Services;
using System.Text.Json;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly ITauxDeChangeService _tauxDeChangeService;

    public TransactionController(ITransactionService transactionService, ITauxDeChangeService tauxDeChangeService)
    {
        _transactionService = transactionService;
        _tauxDeChangeService = tauxDeChangeService;
    }

    [HttpPost("generate-file-transaction")]
    public async Task<IActionResult> GenerateFileTransaction()
    {
        var transactions = new List<TransactionDto>
            {
              new TransactionDto { NumeroCarte = "4974 0185 0223 4567", Montant = 340, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2018, 5, 8, 12, 23, 27), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 8951", Montant = 219, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2020, 6, 12, 16, 11, 54), Devise = "CAD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 3824", Montant = 61, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2020, 4, 20, 13, 26, 25), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 5738", Montant = 222, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2021, 7, 16, 12, 57, 36), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 4012", Montant = 238, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2019, 6, 6, 5, 39, 59), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 7456", Montant = 241, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2020, 5, 25, 1, 48, 56), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 9463", Montant = 283, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2022, 3, 27, 20, 37, 59), Devise = "CHF" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 1230", Montant = 312, TypeOperation = "Facture CB", DateOperation = new DateTime(2020, 11, 20, 11, 58, 22), Devise = "USD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 2569", Montant = 301, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2021, 7, 31, 14, 57, 1), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 7654", Montant = 446, TypeOperation = "Facture CB", DateOperation = new DateTime(2021, 3, 16, 1, 15, 8), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 1347", Montant = 220, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2020, 8, 16, 4, 44, 53), Devise = "CHF" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 5941", Montant = 80, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2018, 3, 16, 3, 55, 30), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 8713", Montant = 439, TypeOperation = "Facture CB", DateOperation = new DateTime(2020, 2, 11, 14, 51, 27), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 2698", Montant = 187, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2019, 3, 24, 13, 56, 18), Devise = "CAD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 8452", Montant = 158, TypeOperation = "Facture CB", DateOperation = new DateTime(2018, 4, 27, 19, 55, 1), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 3092", Montant = 323, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2021, 11, 13, 15, 46, 3), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 4530", Montant = 444, TypeOperation = "Dépôt Guichet", DateOperation = new DateTime(2019, 8, 24, 10, 14, 22), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 7620", Montant = 281, TypeOperation = "Dépôt Guichet", DateOperation = new DateTime(2018, 2, 19, 7, 0, 21), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 6394", Montant = 481, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2018, 12, 1, 6, 32, 3), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4974 0185 0223 1264", Montant = 129, TypeOperation = "Facture CB", DateOperation = new DateTime(2018, 9, 15, 1, 57, 20), Devise = "JPY" }
            };
        var json = JsonSerializer.Serialize(transactions);
        await System.IO.File.WriteAllTextAsync("transactions_generated.json", json);
        return Ok("Fichier de transactions généré.");
    }

    [HttpPost("read-file-transactions")]
    public async Task<IActionResult> ReadFileTransactions()
    {
        var json = await System.IO.File.ReadAllTextAsync("transactions_generated.json");
        var transactions = JsonSerializer.Deserialize<List<TransactionDto>>(json);
        foreach (var transaction in transactions)
        {
            await _transactionService.ProcessTransaction(transaction);
        }
        return Ok("Transactions vérifiées et enregistrées.");
    }

    [HttpGet("generate-file-verif-transaction")]
    public async Task<IActionResult> GenerateFileVerifTransaction()
    {
        var transactions = await _transactionService.GetValidTransactionsAsync();

        var transactionDtos = new List<TransactionDto>();

        foreach (var transaction in transactions)
        {
            decimal tauxDeChange = await _tauxDeChangeService.GetTauxDeChangeAsync(transaction.Devise);

            var transactionDto = new TransactionDto
            {
                Id = transaction.Id,
                NumeroCarte = transaction.NumeroCarte,
                Montant = transaction.Montant,
                TypeOperation = transaction.TypeOperation,
                DateOperation = transaction.DateOperation,
                Devise = transaction.Devise,
                TauxDeChange = tauxDeChange
            };

            transactionDtos.Add(transactionDto);
        }

        var json = JsonSerializer.Serialize(transactionDtos, new JsonSerializerOptions { WriteIndented = true });

        await System.IO.File.WriteAllTextAsync("transactions_validated.json", json);

        return Ok("Fichier de transactions validés généré.");
    }
}