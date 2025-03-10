using System;

/// <summary>
/// MyDbContext
/// </summary>
public class MyDbContext : DbContext
{
	public DbSet<Client> Clients { get; set; }
    public DbSet<ClientParticulier> ClientsParticuliers { get; set; }
    public DbSet<ClientProfessionel> ClientsProfessionels { get; set; }
    public DbSet<CompteBancaire> ComptesBancaires { get; set; }
    public DbSet<TransactionBancaire> TransactionsBancaires { get; set; }

    public MyDbContext(DbContextOpations<MyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().UseTpcMappingStrategy();
    }

}
