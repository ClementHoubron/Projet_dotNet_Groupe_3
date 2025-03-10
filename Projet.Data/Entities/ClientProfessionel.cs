using System;
using System.ComponentModel.DataAnnotations;


namespace Projet.Data.Entities 
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
        [RegularExpression("[1-9]{14}", ErrorMessage = "Siret needs to be 14 numbers.")]
        public string Siret { get; set; }
        public StatutJuridique StatutJuridique { get; set; }
        public Adresse AdresseSiege { get; set; }
    }
    

}