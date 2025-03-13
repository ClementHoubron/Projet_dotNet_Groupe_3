using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


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
            return VerifyPassword(mdp, admin.MotDePasse);

        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return hashedPassword == Convert.ToBase64String(hash);
            }
        }


    }
}
