using System;

/// <summary>
/// Transaction Bancaire DTO
/// </summary>
public class TransactionBancaireDto
{
    public int Id { get; set; }
    public string NumeroCarte { get; set; }
    public decimal Montant { get; set; }
    public string TypeOperation { get; set; }
    public DateTime DateOperation { get; set; }
    public string Devise { get; set; }
    public int CompteBancaireId { get; set; }
    public bool EstValide { get; set; }
}