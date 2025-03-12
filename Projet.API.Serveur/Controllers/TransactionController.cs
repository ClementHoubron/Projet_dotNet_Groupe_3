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
              new TransactionDto { NumeroCarte = "4296894611591822", Montant = 340, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2018, 5, 8, 12, 23, 27), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4742877819805129", Montant = 219, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2020, 6, 12, 16, 11, 54), Devise = "CAD" },
              new TransactionDto { NumeroCarte = "4494930712100415", Montant = 61, TypeOperation = "Opération Invalide", DateOperation = new DateTime(2020, 4, 20, 13, 26, 25), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4431509177505985", Montant = 222, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2021, 7, 16, 12, 57, 36), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4227130259556842", Montant = 238, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2019, 6, 6, 5, 39, 59), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4671267800285623", Montant = 241, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2020, 5, 25, 1, 48, 56), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4868798527121635", Montant = 283, TypeOperation = "Transfert Non Autorisé", DateOperation = new DateTime(2022, 3, 27, 20, 37, 59), Devise = "CHF" },
              new TransactionDto { NumeroCarte = "4662584179164583", Montant = 312, TypeOperation = "Facture CB", DateOperation = new DateTime(2020, 11, 20, 11, 58, 22), Devise = "USD" },
              new TransactionDto { NumeroCarte = "4283787819212929", Montant = 301, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2021, 7, 31, 14, 57, 1), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4070642108142536", Montant = 446, TypeOperation = "Facture CB", DateOperation = new DateTime(2021, 3, 16, 1, 15, 8), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4227720450022105", Montant = 220, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2020, 8, 16, 4, 44, 53), Devise = "CHF" },
              new TransactionDto { NumeroCarte = "4488586424609297", Montant = 80, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2018, 3, 16, 3, 55, 30), Devise = "GBP" },
              new TransactionDto { NumeroCarte = "4013523602955649", Montant = 439, TypeOperation = "Facture CB", DateOperation = new DateTime(2020, 2, 11, 14, 51, 27), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4487880156591642", Montant = 187, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2019, 3, 24, 13, 56, 18), Devise = "CAD" },
              new TransactionDto { NumeroCarte = "4979253650995682", Montant = 158, TypeOperation = "Facture CB", DateOperation = new DateTime(2018, 4, 27, 19, 55, 1), Devise = "JPY" },
              new TransactionDto { NumeroCarte = "4664847677082643", Montant = 323, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2021, 11, 13, 15, 46, 3), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4836373185491268", Montant = 444, TypeOperation = "Dépôt Guichet", DateOperation = new DateTime(2019, 8, 24, 10, 14, 22), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4482725017937103", Montant = 281, TypeOperation = "Dépôt Guichet", DateOperation = new DateTime(2018, 2, 19, 7, 0, 21), Devise = "EUR" },
              new TransactionDto { NumeroCarte = "4135915500745917", Montant = 481, TypeOperation = "Retrait DAB", DateOperation = new DateTime(2018, 12, 1, 6, 32, 3), Devise = "AUD" },
              new TransactionDto { NumeroCarte = "4224378676607088", Montant = 129, TypeOperation = "Facture CB", DateOperation = new DateTime(2018, 9, 15, 1, 57, 20), Devise = "JPY" }
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