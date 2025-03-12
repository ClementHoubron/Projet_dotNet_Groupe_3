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


    public interface ITransactionRepository : IRepository<TransactionBancaire>
    {
        void AjouterTransactionAvecVerification(TransactionBancaire transaction);
        void GenererFichierTransactions();


    }

    public class TransactionRepository : IRepository<TransactionBancaire>, ITransactionRepository
    {
        protected readonly MyDbContext _context;
        public TransactionRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }



        public void AjouterTransactionAvecVerification(TransactionBancaire transaction)
        {
            if (!ValiderNumeroCarte(transaction.NumeroCarte))
            {
                Console.WriteLine("TODO");
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
            var transactionsValides = _context.TransactionsBancaires.ToList();
            string json = JsonConvert.SerializeObject(transactionsValides, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("transactions_validees.json", json);
        }

        public async Task<List<TransactionBancaire>> GetAll()
        {
            using var context = new MyDbContext();
            var transactions = await _context.TransactionsBancaires
                                             .Include("ComptesBancaires")
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

        public async Task<List<TransactionBancaire>> GetAllByNumCarte(string numCarte)
        {
            using var context = new MyDbContext();
            var transactions = await _context.TransactionsBancaires
                                             .Where<TransactionBancaire>(t => t.NumeroCarte == numCarte)
                                             .Include("ComptesBancaires")
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }
        public async Task<List<TransactionBancaire>> GetAllByNumCompte(string numCompte)
        {
            using var context = new MyDbContext();
            var transactions = await _context.TransactionsBancaires
                                             .Include("ComptesBancaires")
                                             .Where<TransactionBancaire>(t => t.CompteBancaireNumeroCompte == numCompte)
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

        public async Task<List<TransactionBancaire>> GetAllByNumCompteForPeriod(string numCompte, DateTime before, DateTime after)
        {
            using var context = new MyDbContext();
            var transactions = await _context.TransactionsBancaires
                                             .Include("ComptesBancaires")
                                             .Where<TransactionBancaire>(t => t.CompteBancaireNumeroCompte == numCompte && (t.DateOperation >= before && t.DateOperation <= after))
                                             .ToListAsync<TransactionBancaire>();
            return transactions;
        }

    }
}