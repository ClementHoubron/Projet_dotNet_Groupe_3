using Microsoft.EntityFrameworkCore;
using Projet.Serveur.Data.Entities;
using Projet.Serveur.Data.Repositories;
using System;

/// <summary>
/// MyDbContext
/// </summary>
public class MyDbContext : DbContext
{

    public DbSet<TransactionBancaire> TransactionBancaire { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotNetProjetServeur;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TransactionBancaire>().ToTable<TransactionBancaire>("TransactionBancaire");
    }

}