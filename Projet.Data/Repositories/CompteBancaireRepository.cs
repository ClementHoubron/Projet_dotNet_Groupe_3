using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Data.Repositories
{
    public class CompteBancaireRepository : IRepository<CompteBancaire>
    {
        public CompteBancaireRepository()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async void Add(CompteBancaire compte)
        {
            using var context = new MyDbContext();
            await context.ComptesBancaires.AddAsync(compte);
            await context.SaveChangesAsync();
        }

        public async Task<List<CompteBancaire>> GetAll()
        {
            using var context = new MyDbContext();
            var comptes = await context.ComptesBancaires
                                       .ToListAsync<CompteBancaire>();
            return comptes;
        }

        public async Task<CompteBancaire?> GetByNum(string numCb)
        {
            using var context = new MyDbContext();
            var compte = await context.ComptesBancaires
                                      .Where<CompteBancaire>(c => c.NumeroCompte == numCb)
                                      .SingleOrDefaultAsync<CompteBancaire>();
            return compte;
        }

        public async void UpdateSolde(CompteBancaire compte)
        {
            using var context = new MyDbContext();
            var compteToUpdate = await context.ComptesBancaires
                                      .Where<CompteBancaire>(c => c.NumeroCompte == compte.NumeroCompte)
                                      .SingleOrDefaultAsync<CompteBancaire>();
            if (compteToUpdate != null)
            {
                context.ComptesBancaires.Update(compte);
                await context.SaveChangesAsync();
            }

        }
    }
}
