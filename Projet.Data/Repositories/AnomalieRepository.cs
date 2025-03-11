using Microsoft.EntityFrameworkCore;
using Projet.Data.Entities;
using Projet.Data.Repositories;
using System.Collections.Generic;

public class AnomalieRepository : IRepository<AnomalieTransaction>
{

    public AnomalieRepository()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var context = new MyDbContext();
        context.Database.EnsureCreated();
    }


    public async Task<List<AnomalieTransaction>> GetAll()
    {
        using var context = new MyDbContext();
        return await context.AnomaliesTransactions.ToListAsync();
    }


}