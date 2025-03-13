using Projet.AppClient.Data.Entities;
using Projet.AppClient.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.View
{
    public class ClientView
    {
        public void DisplayClient(ClientDto cli)
        {
            if (cli != null)
            {
                Console.WriteLine(cli.ToString());
            }
            else
                Console.WriteLine("Pas de client correspondant.");
        }

        public void DisplayClientList(List<ClientDto> clients)
        {
            foreach (var client in clients)
            {
                DisplayClient(client);
            }
        }

        public ClientParticulierDto GetClientParticulierDetails()
        {
            #region saisie
            Console.WriteLine("Saisir le nom du client");
            string nom = Console.ReadLine();

            Console.WriteLine("Saisir le prenom du client");
            string prenom = Console.ReadLine();

            Console.WriteLine("Saisir le libelle du client");
            string libelle = Console.ReadLine();

            Console.WriteLine("Saisir le complement du client");
            string complement = Console.ReadLine();

            Console.WriteLine("Saisir la ville du client");
            string ville = Console.ReadLine();

            Console.WriteLine("Saisir le code postal du client");
            string codePostal = Console.ReadLine();

            Console.WriteLine("Saisir le mail du client");
            string mail = Console.ReadLine();


            Console.WriteLine("Saisir le sexe du client");
            string sexe = Console.ReadLine();

            Console.WriteLine("Saisir la date de naissance du client");
            string dateNaiss = Console.ReadLine();

            #endregion

            ClientParticulierDto cliToAdd = new ClientParticulierDto()
            {
                Nom = nom,
                Prenom = prenom,
                AdressePostale = new AdresseParticulier
                {
                    Libelle = libelle,
                    Complement = complement,
                    Ville = ville,
                    CodePostal = codePostal
                },
                Email = mail,
                Sexe = (Sexe)Enum.Parse(typeof(Sexe),sexe),
                DateNaissance = DateTime.Parse(dateNaiss)

            };

            if (!Validate(cliToAdd) | !ValidateAdresseParticulier(cliToAdd))
            {
                throw new ArgumentException("Saisie client professionnel incorrecte.");
            }
            return cliToAdd;
        }


        public ClientProfessionnelDto GetClientProfessionnelDetails()
        {
            #region saisie
            Console.WriteLine("Saisir le nom du client");
            string nom = Console.ReadLine();

            Console.WriteLine("Saisir le libelle du client");
            string libelle = Console.ReadLine();

            Console.WriteLine("Saisir le complement du client");
            string complement = Console.ReadLine();

            Console.WriteLine("Saisir la ville du client");
            string ville = Console.ReadLine();

            Console.WriteLine("Saisir le code postal du client");
            string codePostal = Console.ReadLine();

            Console.WriteLine("Saisir le mail du client");
            string mail = Console.ReadLine();

            Console.WriteLine("Saisir le SIRET du client");
            string siret = Console.ReadLine();

            Console.WriteLine("Saisir le Statut juridique du client");
            string statutJuridique = Console.ReadLine();

            Console.WriteLine("Saisir le libelle du siège du client");
            string libelleSiege = Console.ReadLine();

            Console.WriteLine("Saisir le complement du siège du client");
            string complementSiege = Console.ReadLine();

            Console.WriteLine("Saisir la ville du siège du  client");
            string villeSiege = Console.ReadLine();

            Console.WriteLine("Saisir le code postal du siège du client");
            string codePostalSiege = Console.ReadLine();
            #endregion

            ClientProfessionnelDto cliToAdd = new ClientProfessionnelDto()
            {
                Nom = nom,
                AdressePostale = new AdresseParticulier
                {
                    Libelle = libelle,
                    Complement = complement,
                    Ville = ville,
                    CodePostal = codePostal
                },
                Email = mail,
                Siret = siret,
                StatutJuridique = (StatutJuridique)Enum.Parse(typeof(StatutJuridique), statutJuridique),
                AdresseSiege = new AdresseProfessionnel
                {
                    Libelle = libelleSiege,
                    Complement = complementSiege,
                    Ville = villeSiege,
                    CodePostal = codePostalSiege
                }


            };

            if (!Validate(cliToAdd) | !ValidateAdresseProfessionnel(cliToAdd))
            {
                throw new ArgumentException("Saisie client professionnel incorrecte.");
            }
            return cliToAdd;
        }
        private bool Validate(object obj)
        {
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    Console.WriteLine($"\tErreur : {error.ErrorMessage}");
                }

            }
            return isValid;
        }

        private bool ValidateAdresseProfessionnel(ClientProfessionnelDto cli)
        {
            var context = new ValidationContext(cli.AdresseSiege);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(cli.AdresseSiege, context, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    Console.WriteLine($"\tErreur : {error.ErrorMessage}");
                }

            }


            context = new ValidationContext(cli.AdressePostale);
            results = new List<ValidationResult>();
            isValid &= Validator.TryValidateObject(cli.AdressePostale, context, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    Console.WriteLine($"\tErreur : {error.ErrorMessage}");
                }

            }
            return isValid;
        }

        private bool ValidateAdresseParticulier(ClientParticulierDto cli)
        {
            var context = new ValidationContext(cli.AdressePostale);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(cli.AdressePostale, context, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    Console.WriteLine($"\tErreur : {error.ErrorMessage}");
                }

            }
            return isValid;
        }
    }
}
