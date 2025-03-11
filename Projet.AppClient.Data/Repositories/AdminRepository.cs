using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet.AppClient.Data.Repositories
{
    public class AdminRepository: IRepository<Admin>
    {
        public AdminRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async Task<List<Admin>> GetAll()
        {
            using var context = new MyDbContext();
            var admins = await context.Admins
                                        .Include("ComptesBancaires")
                                        .ToListAsync<Admin>();
            return admins;
        }

        public async Task<bool> Login(string login, string mdp)
        {
            using var context = new MyDbContext();
            var admin = await context.Admins.FindAsync(login);
            if (admin is null)
            {
                return false;
            }
            return admin.MotDePasse == mdp;

        }


    }
}
