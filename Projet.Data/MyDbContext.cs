using Microsoft.EntityFrameworkCore;
using Projet.Data.Entities;
using System;

/// <summary>
/// MyDbContext
/// </summary>
public class MyDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientParticulier> ClientsParticuliers { get; set; }
    public DbSet<ClientProfessionnel> ClientsProfessionels { get; set; }
    public DbSet<CompteBancaire> ComptesBancaires { get; set; }
    public DbSet<TransactionBancaire> TransactionsBancaires { get; set; }
    public DbSet<AnomalieTransaction> AnomaliesTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotNetProjet;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().UseTpcMappingStrategy();
    }

}