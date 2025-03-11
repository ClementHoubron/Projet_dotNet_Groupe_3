using Projet.Serveur.Data.Entities;


namespace Projet.Serveur.Data.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(TransactionBancaire transaction);
        IEnumerable<TransactionBancaire> GetValidTransactions();
        IEnumerable<TransactionBancaire> GetAnomalies();
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyDbContext _context;

        public TransactionRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AddTransaction(TransactionBancaire transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public IEnumerable<TransactionBancaire> GetValidTransactions()
        {
            return _context.Transactions.Where(t => t.EstValide).ToList();
        }

        public IEnumerable<TransactionBancaire> GetAnomalies()
        {
            return _context.Transactions.Where(t => !t.EstValide).ToList();
        }
    }
}