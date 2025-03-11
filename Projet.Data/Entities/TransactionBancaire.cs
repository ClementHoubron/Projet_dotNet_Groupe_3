using System;

/// <summary>
/// entity of TransactionBancaire
/// </summary>
public class TransactionBancaire
{
    public int Id { get; set; }
    public string NumeroCompte { get; set; }
    public decimal Montant { get; set; }
    public string TypeOperation { get; set; }
    public DateTime DateOperation { get; set; }
    public string Devise { get; set; }
    public int CompteBancaireId { get; set; }
    public CompteBancaire CompteBancaire { get; set; }
    public bool EstValide { get; set; } = true;
}
