﻿using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Entities;
using Projet.AppClient.Data.Repositories;
using System;

/// <summary>
/// MyDbContext
/// </summary>
public class MyDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientParticulier> ClientsParticuliers { get; set; }
    public DbSet<ClientProfessionnel> ClientsProfessionnels { get; set; }
    public DbSet<AdresseParticulier> AdressesParticulier { get; set; }
    public DbSet<AdresseProfessionnel> AdressesProfessionnels { get; set; }
    public DbSet<CompteBancaire> ComptesBancaires { get; set; }
    public DbSet<CarteBancaire> CartesBancaires { get; set; }
    public DbSet<TransactionBancaire> TransactionsBancaires { get; set; }

    public DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotNetProjetClient;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Client>().UseTpcMappingStrategy();

        modelBuilder.Entity<TransactionBancaire>().Property(t => t.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<CarteBancaire>()
                    .HasOne(ca => ca.CompteBancaire)
                    .WithMany(co => co.CartesBancaire)
                    .HasForeignKey(ca => ca.CompteBancaireNumeroCompte);

        modelBuilder.Entity<TransactionBancaire>()
                    .HasOne(t => t.CompteBancaire)
                    .WithMany(co => co.TransactionBancaires)
                    .HasForeignKey(t => t.CompteBancaireNumeroCompte);

        #region AddresseParticulier
        modelBuilder.Entity<AdresseParticulier>().HasData(
           new AdresseParticulier
           {
               Id = 1,
               Libelle = "12, rue des Oliviers",
               Complement = "",
               Ville = "CRETEIL",
               CodePostal = "94000"
           }
           );

        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 2,
                Libelle = "10, rue des Olivies",
                Complement = "Etage 2",
                Ville = "VINCENNES",
                CodePostal = "94300"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 3,
                Libelle = "15, rue de la République",
                Complement = "",
                Ville = "FONTENAY SOUS BOIS",
                CodePostal = "94120"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 4,
                Libelle = "25, rue de la Paix",
                Complement = "",
                Ville = "LA DEFENSE",
                CodePostal = "92100"
            }
            );

        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 5,
                Libelle = "3, aveenue des Parcs",
                Complement = "",
                Ville = "ROISSY EN France",
                CodePostal = "93500"
            }
            );

        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 6,
                Libelle = "3, rue Lecourbe",
                Complement = "",
                Ville = "BAGNOLET",
                CodePostal = "93200"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 7,
                Libelle = "125, rue LaFayette",
                Complement = "digicode 1432",
                Ville = "FONTENAY SOUS BOIS",
                CodePostal = "94120"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 8,
                Libelle = "36, quai des Orfèvres",
                Complement = "",
                Ville = "ROISSY EN FRANCE",
                CodePostal = "93500"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 9,
                Libelle = "32, rue E. Renan",
                Complement = "Bat. C",
                Ville = "PARIS",
                CodePostal = "75002"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 10,
                Libelle = "23, av P. Valery",
                Complement = "",
                Ville = "LA DEFENSE",
                CodePostal = "92100"
            }
            );


        modelBuilder.Entity<AdresseParticulier>().HasData(
            new AdresseParticulier
            {
                Id = 11,
                Libelle = "15, Place de la Bastille",
                Complement = "Fond de Cour",
                Ville = "PARIS",
                CodePostal = "75003"
            }
            );

        #endregion

        #region AdressePro
        modelBuilder.Entity<AdresseProfessionnel>().HasData(
           new AdresseProfessionnel
           {
               Id = 1,
               Libelle = "125, rue LaFayette",
               Complement = "Digicode 1432",
               Ville = "FONTENAY SOUS BOIS",
               CodePostal = "94120"
           }
           );


        modelBuilder.Entity<AdresseProfessionnel>().HasData(
            new AdresseProfessionnel
            {
                Id = 2,
                Libelle = "10, esplanade de la Défense",
                Complement = "",
                Ville = "LA DEFENSE",
                CodePostal = "92060"
            }
            );


        modelBuilder.Entity<AdresseProfessionnel>().HasData(
            new AdresseProfessionnel
            {
                Id = 3,
                Libelle = "32, rue E. Renan",
                Complement = "Bat. C",
                Ville = "Paris",
                CodePostal = "75002"
            }
            );

        modelBuilder.Entity<AdresseProfessionnel>().HasData(
            new AdresseProfessionnel
            {
                Id = 4,
                Libelle = "24, esplanade de la Défense",
                Complement = "Tour Franklin",
                Ville = "LA DEFENSE",
                CodePostal = "92060"
            }
            );

        modelBuilder.Entity<AdresseProfessionnel>().HasData(
            new AdresseProfessionnel
            {
                Id = 5,
                Libelle = "10, rue de la Paix",
                Complement = "",
                Ville = "PARIS",
                CodePostal = "75008"
            }
            );
        #endregion

        #region ClientParticulier
        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 1,
                Nom = "BETY",
                Email = "bety@gmail.com",
                Prenom = "Daniel",
                Sexe = Sexe.M,
                DateNaissance = new DateTime(1985, 11, 12),
                AdressePostaleId = 1,

            });


        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 3,
                Nom = "BODIN",
                Email = "bodin@gmail.com",
                Prenom = "Justin",
                Sexe = Sexe.M,
                DateNaissance = new DateTime(1965, 05, 05),
                AdressePostaleId = 2,

            });

        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 5,
                Nom = "BERRIS",
                Email = "berris@gmail.com",
                Prenom = "Karine",
                Sexe = Sexe.F,
                DateNaissance = new DateTime(1977, 06, 06),
                AdressePostaleId = 3,

            });

        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 7,
                Nom = "ABENIR",
                Email = "abenir@gmail.com",
                Prenom = "Alexandra",
                Sexe = Sexe.F,
                DateNaissance = new DateTime(1977, 04, 12),
                AdressePostaleId = 4,

            });

        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 9,
                Nom = "BENSAID",
                Email = "bensaid@gmail.com",
                Prenom = "Georgia",
                Sexe = Sexe.F,
                DateNaissance = new DateTime(1976, 04, 16),
                AdressePostaleId = 5

            });

        modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Id = 11,
                Nom = "ABABOU",
                Email = "ababou@gmail.com",
                Prenom = "Teddy",
                Sexe = Sexe.M,
                DateNaissance = new DateTime(1970, 10, 10),
                AdressePostaleId = 6

            });
        #endregion

        #region ClientPro
        modelBuilder.Entity<ClientProfessionnel>().HasData(
           new ClientProfessionnel
           {
               Id = 2,
               Nom = "AXA",
               Email = "info@axa.com",
               Siret = "12548795641122",
               StatutJuridique = StatutJuridique.SARL,
               AdressePostaleId = 7,
               AdresseSiegeId = 1

           });


        modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Id = 4,
                Nom = "PAUL",
                Email = "info@paul.com",
                Siret = "87459564455444",
                StatutJuridique = StatutJuridique.EURL,
                AdressePostaleId = 8,
                AdresseSiegeId = 2

            });

        modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Id = 6,
                Nom = "PRIMARK",
                Email = "info@primark.com",
                Siret = "08755897458455",
                StatutJuridique = StatutJuridique.SARL,
                AdressePostaleId = 9,
                AdresseSiegeId = 3

            });

        modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Id = 8,
                Nom = "ZARA",
                Email = "info@zara.com",
                Siret = "65895874587854",
                StatutJuridique = StatutJuridique.SA,
                AdressePostaleId = 10,
                AdresseSiegeId = 4

            });

        modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Id = 10,
                Nom = "LEONIDAS",
                Email = "info@leonidas.com",
                Siret = "91235987456832",
                StatutJuridique = StatutJuridique.SAS,
                AdressePostaleId = 11,
                AdresseSiegeId = 5

            });
        #endregion


        #region CompteBancaire
        //Exemple : 15/04/2012 15:12:20 -> 12400215 205112

        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "10010224150120",
                DateOuverture = new DateTime(2010, 10, 24, 10, 20, 15),
                Solde = 2000,
                ClientId = 1
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "15200215150112",
                DateOuverture = new DateTime(2015, 2, 15, 10, 12, 15),
                Solde = 500,
                ClientId = 2
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "12500206155124",
                DateOuverture = new DateTime(2012, 5, 6, 15, 24, 15),
                Solde = 4000,
                ClientId = 3
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "14200215428010",
                DateOuverture = new DateTime(2014, 2, 15, 8, 10, 42),
                Solde = 0,
                ClientId = 4
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "18210201384150",
                DateOuverture = new DateTime(2018, 12, 1, 14, 50, 38),
                Solde = -1000,
                ClientId = 5
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "12010203151120",
                DateOuverture = new DateTime(2012, 10, 3, 11, 20, 15),
                Solde = 2000,
                ClientId = 6
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "10800224150145",
                DateOuverture = new DateTime(2010, 8, 24, 10, 45, 15),
                Solde = 2000,
                ClientId = 7
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "14200224159030",
                DateOuverture = new DateTime(2014, 2, 24, 9, 30, 15),
                Solde = 2000,
                ClientId = 8
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "10010224155120",
                DateOuverture = new DateTime(2010, 10, 24, 15, 20, 15),
                Solde = 2000,
                ClientId = 9
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "12400217180147",
                DateOuverture = new DateTime(2012, 4, 17, 10, 47, 18),
                Solde = 2000,
                ClientId = 10
            }
            );
        modelBuilder.Entity<CompteBancaire>().HasData(
            new CompteBancaire
            {
                NumeroCompte = "10400222572138",
                DateOuverture = new DateTime(2010, 4, 22, 12, 38, 57),
                Solde = 2000,
                ClientId = 11
            }
            );


        #endregion

        #region CartesBancaires

        modelBuilder.Entity<CarteBancaire>().HasData(
            new CarteBancaire
            {
                NumeroCarte = "4974018502233824",
                CompteBancaireNumeroCompte = "10010224155120"
            }
            );
        modelBuilder.Entity<CarteBancaire>().HasData(
            new CarteBancaire
            {
                NumeroCarte = "4974018502235738",
                CompteBancaireNumeroCompte = "12400217180147"
            }
            );
        modelBuilder.Entity<CarteBancaire>().HasData(
            new CarteBancaire
            {
                NumeroCarte = "4974018502234012",
                CompteBancaireNumeroCompte = "10400222572138"
            }
            );
        #endregion

        #region TransactionsBancaires
        //modelBuilder.Entity<TransactionBancaire>().HasData(
        //    new TransactionBancaire
        //    {
        //        Id = 1,
        //        NumeroCarte = "4974 0185 0223 4832",
        //        Montant = 150.75m,
        //        TypeOperation = "Retrait",
        //        DateOperation = new DateTime(2024, 3, 1),
        //        Devise = "EUR"
        //    },
        //    new TransactionBancaire
        //    {
        //        Id = 2,
        //        NumeroCarte = "4974 0185 0223 2949",
        //        Montant = 2000.00m,
        //        TypeOperation = "Virement",
        //        DateOperation = new DateTime(2024, 2, 15),
        //        Devise = "USD"
        //    },
        //    new TransactionBancaire
        //    {
        //        Id = 3,
        //        NumeroCarte = "4974 0185 0223 5200",
        //        Montant = 500.50m,
        //        TypeOperation = "Paiement",
        //        DateOperation = new DateTime(2024, 1, 10),
        //        Devise = "EUR"
        //    },
        //    new TransactionBancaire
        //    {
        //        Id = 4,
        //        NumeroCarte = "4974 0185 0223 1783",
        //        Montant = 1200.00m,
        //        TypeOperation = "Dépôt",
        //        DateOperation = new DateTime(2024, 3, 5),
        //        Devise = "GBP"
        //    },
        //    new TransactionBancaire
        //    {
        //        Id = 5,
        //        NumeroCarte = "4974 0185 0223 0002",
        //        Montant = 50.00m,
        //        TypeOperation = "Retrait",
        //        DateOperation = new DateTime(2024, 2, 28),
        //        Devise = "EUR"
        //    },
        //    new TransactionBancaire
        //    {
        //        Id = 6,
        //        NumeroCarte = "4974 0185 0223 0102",
        //        Montant = 300.00m,
        //        TypeOperation = "Paiement",
        //        DateOperation = new DateTime(2024, 3, 7),
        //        Devise = "USD"
        //    }
        //);
        #endregion

        #region Admin
        var admin = new Admin { Login = "Admin"};
        admin.SetPassword("12345");
        #endregion
        modelBuilder.Entity<Admin>().HasData(admin);
        modelBuilder.Entity<CompteBancaire>().ToTable<CompteBancaire>("ComptesBancaires");
        modelBuilder.Entity<AdresseParticulier>().ToTable<AdresseParticulier>("AdressesParticulier");
        modelBuilder.Entity<Client>().UseTpcMappingStrategy();
        modelBuilder.Entity<Client>().Property(t => t.Id).ValueGeneratedOnAdd();
    }

}