using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public interface ITransactionRepository : IRepository<TransactionBancaire>
{
    IEnumerable<TransactionBancaire> GetTransactionsByAccountId(int compteId);
    void AjouterTransactionAvecVerification(TransactionBancaire transaction);
    void GenererFichierTransactions();
}

public class TransactionRepository : Repository<TransactionBancaire>, ITransactionRepository
{
    protected readonly MyDbContext _context;
    public TransactionRepository(MyDbContext context) : base(context) { }

    public IEnumerable<TransactionBancaire> GetTransactionsByAccountId(int compteId)
    {
        return _context.TransactionsBancaires.Where(t => t.CompteBancaireId == compteId).ToList();
    }

    public void AjouterTransactionAvecVerification(TransactionBancaire transaction)
    {
        if (!ValiderNumeroCarte(transaction.NumeroCarte))
        {
            _context.AnomaliesTransactions.Add(new AnomalieTransaction
            {
                NumeroCarte = transaction.NumeroCarte,
                Montant = transaction.Montant,
                TypeOperation = transaction.TypeOperation,
                DateOperation = transaction.DateOperation,
                Devise = transaction.Devise,
                Motif = "Numéro de carte invalide"
            });
        }
        else
        {
            _context.TransactionsBancaires.Add(transaction);
        }
        _context.SaveChanges();
    }

    private bool ValiderNumeroCarte(string numeroCarte)
    {
        int sum = 0;
        bool alternate = false;
        for (int i = numeroCarte.Length - 1; i >= 0; i--)
        {
            int n = int.Parse(numeroCarte[i].ToString());
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        return (sum % 10 == 0);
    }

    public void GenererFichierTransactions()
    {
        var transactionsValides = _context.TransactionsBancaires.Where(t => t.EstValide).ToList();
        string json = JsonConvert.SerializeObject(transactionsValides, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("transactions_validees.json", json);
    }
}