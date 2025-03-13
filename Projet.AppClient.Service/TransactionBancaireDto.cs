using Projet.AppClient.Data.Entities;
using System;

namespace Projet.AppClient.Service
{


    public class TransactionBancaireDto
    {
        public int Id { get; set; }
        public string NumeroCarte { get; set; }
        public decimal Montant { get; set; }
        public string TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public string Devise { get; set; }
        public string CompteBancaireNumeroCompte { get; set; }
        public CompteBancaire CompteBancaire { get; set; }
    }
}