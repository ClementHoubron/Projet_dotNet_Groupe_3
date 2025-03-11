using Projet.Data.Entities;
using Projet.Service;
using System;
using System.ComponentModel.DataAnnotations;


namespace Projet.Service
{
    public class ClientParticulierDto : ClientDto
    {
        public DateTime DateNaissance { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }
        public Sexe Sexe { get; set; }
    }
}