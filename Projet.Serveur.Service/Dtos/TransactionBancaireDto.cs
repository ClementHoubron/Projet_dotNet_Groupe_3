using System;

/// <summary>
/// Transaction Bancaire DTO
/// </summary>
public class TransactionDto
{
    public int Id { get; set; }
    public string NumeroCarte { get; set; }
    public decimal Montant { get; set; }
    public string TypeOperation { get; set; }
    public DateTime DateOperation { get; set; }
    public string Devise { get; set; }
    public decimal TauxDeChange { get; set; }

}