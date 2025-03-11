using System;

namespace Projet.AppClient.Data.Entities
{
    public class TransactionBancaire
    {
        public int Id { get; set; }
        public string NumeroCarte { get; set; }
        public decimal Montant { get; set; }
        public string TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public string Devise { get; set; }
        public CompteBancaire CompteBancaire { get; set; }
        public bool EstValide { get; set; } = true;
    }
}