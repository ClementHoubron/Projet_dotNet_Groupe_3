using Projet.Data.Entities;
using Projet.Service;
using System;
using System.ComponentModel.DataAnnotations;


namespace Projet.Service
{
    public class ClientProfessionnelDto : ClientDto
    {
        public string Siret { get; set; }
        public StatutJuridique StatutJuridique { get; set; }

        public int AdresseSiegeId { get; set; }
        public AdresseProfessionnel AdresseSiege { get; set; }
    }
}