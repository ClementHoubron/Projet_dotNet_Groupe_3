using Microsoft.EntityFrameworkCore;
using Projet.Serveur.Data.Entities;

namespace Projet.Serveur.Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotNetProjetServeur;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
        public DbSet<TransactionBancaire> Transactions { get; set; }

    }
}