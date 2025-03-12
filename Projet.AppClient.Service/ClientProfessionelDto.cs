using Projet.AppClient.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using Projet.AppClient.Data.Entities;


namespace Projet.AppClient.Service
{
    public class ClientProfessionnelDto : ClientDto
    {
        public string Siret { get; set; }
        public StatutJuridique StatutJuridique { get; set; }

        public int AdresseSiegeId { get; set; }
        public AdresseProfessionnel AdresseSiege { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" {Siret} {StatutJuridique} {AdresseSiege.ToString()}";
        }
    }
}