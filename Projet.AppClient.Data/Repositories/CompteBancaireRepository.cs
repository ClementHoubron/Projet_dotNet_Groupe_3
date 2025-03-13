using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projet.AppClient.Data.Repositories
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
            DateTime date = compte.DateOuverture;
            string newNumCompte = GenerateNumCompte(date);
            while (await GetByNum(newNumCompte) != null)
            {
                newNumCompte = GenerateNumCompte(date.AddHours(1));
            }
            compte.NumeroCompte = newNumCompte;
            await context.ComptesBancaires.AddAsync(compte);
            await context.SaveChangesAsync();
        }

        public async Task<List<CompteBancaire>> GetAll()
        {
            using var context = new MyDbContext();
            var comptes = await context.ComptesBancaires
                                       .Include("Client")
                                       .ToListAsync<CompteBancaire>();
            return comptes;
        }

        public async Task<CompteBancaire?> GetByNum(string numCb)
        {
            using var context = new MyDbContext();
            var compte = await context.ComptesBancaires
                                      .Where<CompteBancaire>(c => c.NumeroCompte == numCb)
                                      .Include("Client")
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

        public string GenerateNumCompte(DateTime date)
        {
            //Utilisation de la date pour créer un numero de compte unique
            //Exemple : 15/04/2012 15:12:20 -> 12400215205112
            string day = date.Day.ToString("D2");     
            string month = date.Month.ToString("D2"); 
            string year = date.Year.ToString();     
            string hour = date.Hour.ToString("D2");   
            string minute = date.Minute.ToString("D2"); 
            string second = date.Second.ToString("D2"); 

            return $"{year.Substring(2)}{month.Reverse()}{year.Substring(0,2).Reverse()}{day}{second}{hour.Reverse()}{minute}";
        }
    }
}
