using Projet.Serveur.Data.Entities;

namespace Projet.Serveur.Data.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetValidTransactions();
        IEnumerable<Transaction> GetAnomalies();
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyDbContext _context;

        public TransactionRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public IEnumerable<Transaction> GetValidTransactions()
        {
            return _context.Transactions.Where(t => t.EstValide).ToList();
        }

        public IEnumerable<Transaction> GetAnomalies()
        {
            return _context.Transactions.Where(t => !t.EstValide).ToList();
        }
    }
}