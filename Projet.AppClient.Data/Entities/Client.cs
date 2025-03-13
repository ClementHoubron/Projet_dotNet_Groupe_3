using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;



namespace Projet.AppClient.Data.Entities
{
    /// <summary>
    /// Entity of Client
    /// </summary>
    public abstract class Client
    {
        [Key]
        [XmlIgnore]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [XmlElement("Nom")]
        public string Nom { get; set; }

        [XmlIgnore]
        public int AdressePostaleId { get; set; }
        [XmlElement("Adresse")]
        public AdresseParticulier AdressePostale { get; set; }

        [RegularExpression(".*@.*", ErrorMessage = "Email needs to contain an @.")]
        [XmlElement("Email")]
        public string Email { get; set; }
        [XmlIgnore]
        public ICollection<CompteBancaire> ComptesBancaires { get; set; }
    }
}