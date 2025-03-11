using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet.AppClient.Data.Repositories
{
    public class ClientRepository: IRepository<Client>
    {
        public ClientRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async Task<List<Client>> GetAll()
        {
            using var context = new MyDbContext();
            var products = await context.Clients
                                        .Include("ComptesBancaires")
                                        .ToListAsync<Client>();
            return products;
        }

    }
}
