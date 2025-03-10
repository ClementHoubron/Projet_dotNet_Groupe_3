using System;
using System.ComponentModel.DataAnnotations;



namespace Projet.Data.Entities
{
    /// <summary>
    /// Entity of Client
    /// </summary>
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }
     
        public Adresse AdressePostale { get; set; }

        [RegularExpression(".*@.*", ErrorMessage = "Email needs to contain an @."]
        public string Email { get; set; }
        public List<CompteBancaire> Comptes { get; set; } = new List<CompteBancaire>();
    }
}