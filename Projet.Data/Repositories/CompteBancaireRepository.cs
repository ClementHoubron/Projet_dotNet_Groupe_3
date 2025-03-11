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
            string newNumCompte = GenerateNumCompte();
            while (await GetByNum(newNumCompte) != null)
            {
                newNumCompte = GenerateNumCompte();
            }
            compte.NumeroCompte = newNumCompte;
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

        public string GenerateNumCompte()
        {
            string baseNumCompte = "4974 0185 0223";
            int baseCount = 58;
            Random rand = new Random();
            int[] endNumCompte = new int[3];

            for (int i = 0; i < 3; i++)
            {
                endNumCompte[i] = rand.Next(0, 10);
            }

            int lastNum = CalculateCheckEndNums(endNumCompte);

            return $"{baseNumCompte}{endNumCompte}{lastNum}";
        }

        public int CalculateCheckEndNums(int[] endNums)
        {
            int sum = 0;
            bool evenNum = false;

            for (int i = endNums.Length - 1; i >= 0; i--)
            {
                int num = endNums[i];

                if (evenNum)
                {
                    num *= 2;
                    if (num > 9)
                    {
                        num -= 9;
                    }
                }

                sum += num;
                evenNum = !evenNum;
            }
            int remaining = sum % 10;
            return (10 - remaining) % 10;
        }
    }
}
