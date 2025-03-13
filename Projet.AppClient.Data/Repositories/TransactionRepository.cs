using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projet.AppClient.Data.Entities;
using Projet.AppClient.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Projet.AppClient.Data.Repositories
{
    public class TransactionRepository : IRepository<TransactionBancaire>
    {
        public TransactionRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public void GenererFichierTransactions()
        {
            using var context = new MyDbContext();
            var transactionsValides = context.TransactionsBancaires.ToList();
            string json = JsonConvert.SerializeObject(transactionsValides, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("transactions_validees.json", json);
        }

        public async Task<List<TransactionBancaire>> GetAll()
        {
            using var context = new MyDbContext();
            var transactions = await context.TransactionsBancaires
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

        public async Task<List<TransactionBancaire>> GetAllByNumCarte(string numCarte)
        {
            using var context = new MyDbContext();
            var transactions = await context.TransactionsBancaires
                                             .Where<TransactionBancaire>(t => t.NumeroCarte == numCarte)
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }
        public async Task<List<TransactionBancaire>> GetAllByNumCompte(string numCompte)
        {
            using var context = new MyDbContext();
            var transactions = await context.TransactionsBancaires
                                             .Where<TransactionBancaire>(t => t.CompteBancaireNumeroCompte == numCompte)
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

        public async Task<List<TransactionBancaire>> GetAllByNumCompteForPeriod(string numCompte, DateTime before, DateTime after)
        {
            using var context = new MyDbContext();
            var transactions = await context.TransactionsBancaires
                                             .Include("CompteBancaire")
                                             .Where<TransactionBancaire>(t => t.CompteBancaireNumeroCompte == numCompte && (t.DateOperation >= before && t.DateOperation <= after))
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

        public async Task<int> ImportAll(List<TransactionBancaire> transactions)
        {
            using var context = new MyDbContext();
            List<TransactionBancaire> transToRemove = new List<TransactionBancaire>();
            foreach (var trans in transactions)
            {
                try
                {
                    var carteB = await context.CartesBancaires
                                      .Where<CarteBancaire>(c => c.NumeroCarte == trans.NumeroCarte)
                                      .Include(c => c.CompteBancaire)
                                      .SingleOrDefaultAsync<CarteBancaire>();
                    var compte = carteB.CompteBancaire;
                    trans.CompteBancaireNumeroCompte = compte.NumeroCompte;
                    compte.Solde += trans.Montant;
                    context.Update(compte);
                } catch (NullReferenceException e)
                {
                    Console.WriteLine($"Erreur : {e.Message}");
                    Console.WriteLine("Cette carte bancaire n'existe pas !");
                    transToRemove.Add(trans);
                }
            }
            foreach (var trans in transToRemove)
            {
                transactions.Remove(trans);
            }
            await context.AddRangeAsync(transactions);
            return await context.SaveChangesAsync();
        }

    }
}