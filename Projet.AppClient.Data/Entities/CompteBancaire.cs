using System;
using System.ComponentModel.DataAnnotations;

namespace Projet.AppClient.Data.Entities
{
    /// <summary>
    /// Entity of CompteBancaire
    /// </summary>
    public class CompteBancaire
    {
        [Key]
        public string NumeroCompte { get; set; }
        [Required]
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; } = 1000.00m;
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}