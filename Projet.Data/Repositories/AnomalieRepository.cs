
using Microsoft.EntityFrameworkCore;
using Projet.Data.Entities;
using System.Collections.Generic;


    public interface IAnomalieRepository : IRepository<AnomalieTransaction>
    {
        IEnumerable<AnomalieTransaction> GetAllAnomalies();
    }

    public class AnomalieRepository : Repository<AnomalieTransaction>, IAnomalieRepository
    {
        public AnomalieRepository(MyDbContext context) : base(context) { }
        protected readonly MyDbContext _context;

        public IEnumerable<AnomalieTransaction> GetAllAnomalies()
        {
            return _context.AnomaliesTransactions.ToList();
        }
    }

