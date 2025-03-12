using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;



namespace Projet.AppClient.Data.Entities
{
    /// <summary>
    /// Entity of Client
    /// </summary>
    public abstract class Client
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }

        public int AdressePostaleId { get; set; }
        public AdresseParticulier AdressePostale { get; set; }

        [RegularExpression(".*@.*", ErrorMessage = "Email needs to contain an @.")]
        public string Email { get; set; }
        public ICollection<CompteBancaire>? ComptesBancaires { get; set; }
    }
}