using Microsoft.EntityFrameworkCore;
using Projet.Serveur.Data.Entities;

namespace Projet.Serveur.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<TransactionBancaire> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionBancaire>().HasData(
                new TransactionBancaire { Id = 1, NumeroCarte = "4974018502231234", Montant = 100.50m, TypeOperation = "Retrait", DateOperation = DateTime.Now, Devise = "EUR", EstValide = true },
                new TransactionBancaire { Id = 2, NumeroCarte = "4974018502235678", Montant = 250.75m, TypeOperation = "Facture CB", DateOperation = DateTime.Now, Devise = "USD", EstValide = true },
                new TransactionBancaire { Id = 3, NumeroCarte = "4974018502239999", Montant = 50.00m, TypeOperation = "Dépôt", DateOperation = DateTime.Now, Devise = "EUR", EstValide = false }
            );
        }
    }
}