

using Projet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projet.Data.Repositories
{

    public class ClientRepository : IRepository<Client>
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
            var clients = await context.Clients
                //.Include("Category")
                .ToListAsync<Client>();

            return clients;
        }
    }
}