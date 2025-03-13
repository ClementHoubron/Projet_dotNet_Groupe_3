using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Data.Repositories
{
    public class CarteBancaireRepository
    {
        public CarteBancaireRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async void Add(CarteBancaire carte)
        {
            using var context = new MyDbContext();
            string newNumCarte = GenerateNumCarte();
            while (await GetByNumCarte(newNumCarte) != null)
            {
                newNumCarte = GenerateNumCarte();
            }
            carte.NumeroCarte = newNumCarte;
            await context.CartesBancaires.AddAsync(carte);
            await context.SaveChangesAsync();
        }

        public async Task<List<CarteBancaire>> GetAll()
        {
            using var context = new MyDbContext();
            var cartes = await context.CartesBancaires
                                      .Include("ComptesBancaires")
                                      .ToListAsync<CarteBancaire>();
            return cartes;
        }

        public async Task<List<CarteBancaire>> GetAllByNumCompte(string numCompte)
        {
            using var context = new MyDbContext();
            var cartes = await context.CartesBancaires
                                      .Where<CarteBancaire>(c => c.CompteBancaire.NumeroCompte == numCompte)
                                      .Include("ComptesBancaires")
                                      .ToListAsync<CarteBancaire>();
            return cartes;
        }
        public async Task<CarteBancaire> GetByNumCarte(string numCarte)
        {
            using var context = new MyDbContext();
            var cartes = await context.CartesBancaires
                                      .Where<CarteBancaire>(c => c.NumeroCarte == numCarte)
                                      .Include("ComptesBancaires")
                                      .SingleOrDefaultAsync<CarteBancaire>();
            return cartes;
        }


        public string GenerateNumCarte()
        {
            string baseNumCarte = "497401850223";
            int baseCount = 58;
            Random rand = new Random();
            int[] endNumCarte = new int[3];

            for (int i = 0; i < 3; i++)
            {
                endNumCarte[i] = rand.Next(0, 10);
            }

            int lastNum = CalculateCheckEndNums(endNumCarte);

            return $"{baseNumCarte}{endNumCarte}{lastNum}";
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
