using System;
using System.ComponentModel.DataAnnotations;


namespace Projet.AppClient.Data.Entities
{
    public enum StatutJuridique
    {
        SARL = 10,
        SA = 20,
        SAS = 30,
        EURL = 40
    }


    /// <summary>
    /// Entity of ClientProfessionnel
    /// </summary>
    ///
    public class ClientProfessionnel : Client
    {
        [Required]
        [RegularExpression("[1-9]{14}", ErrorMessage = "Siret needs to be 14 numbers.")]
        public string Siret { get; set; }

        [Required]
        [RegularExpression("SARL | SA | SAS | EURL", ErrorMessage = "Statut juridique incorrect, saisir : SARL ou SA ou SAS ou EURL")]
        public StatutJuridique StatutJuridique { get; set; }

        
        public int? AdresseSiegeId { get; set; }
        public AdresseProfessionnel AdresseSiege { get; set; }
    }
    

}