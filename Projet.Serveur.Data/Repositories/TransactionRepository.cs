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

        public TransactionRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public void AddTransaction(TransactionBancaire transaction)
        {
            using var _context = new MyDbContext();
            _context.TransactionBancaire.Add(transaction);
            _context.SaveChanges();
        }


        public IEnumerable<TransactionBancaire> GetValidTransactions()
        {
            using var _context = new MyDbContext();
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            return _context.TransactionBancaire
                .Where(t => t.EstValide && t.DateOperation >= today && t.DateOperation < tomorrow)
                .ToList();
        }

        public IEnumerable<TransactionBancaire> GetAnomalies()
        {
            using var _context = new MyDbContext();
            return _context.TransactionBancaire.Where(t => !t.EstValide).ToList();
        }
    }
}