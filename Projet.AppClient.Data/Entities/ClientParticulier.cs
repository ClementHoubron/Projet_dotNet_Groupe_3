using System;
using System.ComponentModel.DataAnnotations;


namespace Projet.AppClient.Data.Entities
{
    public enum Sexe
    {
        F = 10,
        M = 20
    }


    /// <summary>
    /// Entity of ClientParticulier
    /// </summary>
    public class ClientParticulier : Client
    {
        [Required]
        public DateTime DateNaissance { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Prenom { get; set; }

        [Required]
        [RegularExpression("M|F", ErrorMessage = "Saisir M ou F pour le sexe.")]
        public Sexe Sexe { get; set; }
    }

}