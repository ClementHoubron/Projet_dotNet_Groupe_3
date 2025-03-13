using Projet.AppClient.Service;
using System;
using System.ComponentModel.DataAnnotations;
using Projet.AppClient.Data.Entities;


namespace Projet.AppClient.Service
{
    public class ClientParticulierDto : ClientDto
    {
        [Required(ErrorMessage = "Date de naissance requise.")]
        public DateTime DateNaissance { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Prenom requis")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Sexe requis")]
        public Sexe Sexe { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{DateNaissance} {Prenom} {Sexe}";
        }
    }
}