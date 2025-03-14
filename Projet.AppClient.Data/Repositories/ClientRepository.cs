﻿using Microsoft.EntityFrameworkCore;
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
            //var clients = await context.Clients
            //                            .Include("ComptesBancaires")
            //                            .Include(c => c.AdressePostale)
            //                            .ToListAsync<Client>();
            //return clients;
            var clientsParticuliers = await context.ClientsParticuliers
                                            .Include("ComptesBancaires")
                                            .Include(c => c.AdressePostale)
                                            .ToListAsync<ClientParticulier>();

            var ClientsPro = await context.ClientsProfessionnels
                                            .Include("ComptesBancaires")
                                            .Include(c => c.AdressePostale)
                                            .Include(c => c.AdresseSiege)
                                            .ToListAsync<ClientProfessionnel>();
            var clientsParticuliersList = clientsParticuliers.Cast<Client>().ToList();
            var clientsProList = ClientsPro.Cast<Client>().ToList();
            clientsParticuliersList.AddRange(clientsProList);
            return clientsParticuliersList;

        }

        public async Task<int> AddClientParticulier(ClientParticulier cli)
        {
            using var context = new MyDbContext();
            context.ClientsParticuliers.Add(cli);
            var cliSaved = await context.SaveChangesAsync();
            return cliSaved;          
        }

        public async Task<int> AddClientProfessionnel(ClientProfessionnel cli)
        {
            using var context = new MyDbContext();
            context.ClientsProfessionnels.Add(cli);
            var cliSaved = await context.SaveChangesAsync();
            return cliSaved;
        }

        public async Task<ClientParticulier?> GetByNomPrenom(string nom, string prenom)
        {
            using var context = new MyDbContext();
            var cli = await context.ClientsParticuliers
                                        .Where<ClientParticulier>(c => c.Nom.ToUpper().Equals(nom.ToUpper()) && c.Prenom.ToUpper().Equals(prenom.ToUpper()))
                                        .Include("ComptesBancaires")
                                        .Include(c => c.AdressePostale)
                                        .SingleOrDefaultAsync<ClientParticulier>();
            return cli;
        }

        public async Task<ClientProfessionnel?> GetByNomSiret(string nom, string siret)
        {
            using var context = new MyDbContext();
            var cli = await context.ClientsProfessionnels
                                        .Where<ClientProfessionnel>(c => c.Nom.ToUpper().Equals(nom.ToUpper()) && c.Siret.ToUpper().Equals(siret.ToUpper()))
                                        .Include("ComptesBancaires")
                                        .Include(c => c.AdressePostale)
                                        .Include(c => c.AdresseSiege)
                                        .SingleOrDefaultAsync<ClientProfessionnel>();
            return cli;
        }
    }
}
