using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Projet.AppClient.Data.Entities
{
    /// <summary>
    /// Entity of CompteBancaire
    /// </summary>
    public class CompteBancaire
    {
        [Key]
        [XmlIgnore]
        public string NumeroCompte { get; set; }

        [XmlElement("NumeroCompte")]
        public string NumeroCompteMasque
        {
            get
            {
                if (!string.IsNullOrEmpty(NumeroCompte) && NumeroCompte.Length >= 6)
                {
                    return "****" + NumeroCompte.Substring(NumeroCompte.Length - 2);
                }
                return string.Empty;
            }
        }
        [Required]
        [XmlElement("DateOuverture")]
        public DateTime DateOuverture { get; set; }
        [XmlElement("Solde")]
        public decimal Solde { get; set; } = 1000.00m;
        [XmlIgnore]
        public int ClientId { get; set; }
        [XmlIgnore]
        public Client Client { get; set; }
        [XmlIgnore]
        public ICollection<CarteBancaire> CartesBancaire { get; set; }
        [XmlIgnore]
        public ICollection<TransactionBancaire> TransactionBancaires { get; set; }
    }
}