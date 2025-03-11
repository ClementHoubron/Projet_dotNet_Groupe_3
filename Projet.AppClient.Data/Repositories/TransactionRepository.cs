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
            var transactionsValides = _context.TransactionsBancaires.Where(t => t.EstValide).ToList();
            string json = JsonConvert.SerializeObject(transactionsValides, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("transactions_validees.json", json);
        }

        public Task<List<TransactionBancaire>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionBancaire> GetTransactionsByCompte(string carteNum)
        {
            return _context.TransactionsBancaires.Where(t => t.NumeroCarte == carteNum).ToList();
        }

    }
}