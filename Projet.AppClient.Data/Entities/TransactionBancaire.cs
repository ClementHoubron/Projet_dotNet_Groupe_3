using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Projet.AppClient.Data.Entities
{
    public class TransactionBancaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlIgnore]
        public int Id { get; set; }
        [XmlIgnore]
        public string NumeroCarte { get; set; }

        [XmlElement("NumeroCarte")]
        public string NumeroCarteMasque
        {
            get
            {
                if (!string.IsNullOrEmpty(NumeroCarte) && NumeroCarte.Length >= 16)
                {
                    return "**** **** **** " + NumeroCarte.Substring(NumeroCarte.Length - 4);
                }
                return string.Empty;
            }
        }
        [XmlElement("Montant")]
        public decimal Montant { get; set; }
        [XmlElement("TypeOpe")]
        public string TypeOperation { get; set; }
        [XmlElement("DateOpe")]
        public DateTime DateOperation { get; set; }
        [XmlElement("Devise")]
        public string Devise { get; set; }
        [XmlIgnore]
        public string CompteBancaireNumeroCompte { get; set; }
        [XmlIgnore]
        public CompteBancaire CompteBancaire { get; set; }

        public override string ToString()
        {
            if (CompteBancaire != null)
            {
                return $"Id : {Id} NumeroCarte : {NumeroCarte} Montant : {Montant} Devise : {Devise} Compte Bancaire : {CompteBancaire.NumeroCompte}";
            } else
            {
                return $"Id : {Id} NumeroCarte : {NumeroCarte} Montant : {Montant} Devise : {Devise}";
            }
        }
    }
}