using Projet.AppClient.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using Projet.AppClient.Data.Entities;


namespace Projet.AppClient.Service
{
    public class ClientProfessionnelDto : ClientDto
    {
        [Required(ErrorMessage="Siret Requis")]
        public string Siret { get; set; }
        [Required(ErrorMessage = "Statut juridique requis")]
        public StatutJuridique StatutJuridique { get; set; }

        public int AdresseSiegeId { get; set; }

        [Required(ErrorMessage = "Adresse du siège de l'entreprise requise.")]
        public AdresseProfessionnel AdresseSiege { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" {Siret} {StatutJuridique} {AdresseSiege.ToString()}";
        }
    }
}