using Projet.AppClient.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for CompteBancaireDto
/// </summary>
public class CompteBancaireDto
{
    public string NumeroCompte { get; set; }
    [Required]
    public DateTime DateOuverture { get; set; }
    public decimal Solde { get; set; } = 1000.00m;
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public ICollection<CarteBancaire> CartesBancaires { get; set; }
    public ICollection<TransactionBancaire> TransactionsBancaires { get; set; }

}
