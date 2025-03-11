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
        public DateTime DateNaissance { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }
        public Sexe Sexe { get; set; }
    }

}