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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionBancaire>().HasData(
                new TransactionBancaire { Id = 1, NumeroCarte = "4974018502231234", Montant = 100.50m, TypeOperation = "Retrait", DateOperation = new DateTime(2024, 3, 12), Devise = "EUR", EstValide = true },
                new TransactionBancaire { Id = 2, NumeroCarte = "4974018502235678", Montant = 250.75m, TypeOperation = "Facture CB", DateOperation = new DateTime(2024, 4, 9), Devise = "USD", EstValide = true },
                new TransactionBancaire { Id = 3, NumeroCarte = "4974018502239999", Montant = 50.00m, TypeOperation = "Dépôt", DateOperation = new DateTime(2024, 7, 1), Devise = "EUR", EstValide = false }
            );
        }
    }
}