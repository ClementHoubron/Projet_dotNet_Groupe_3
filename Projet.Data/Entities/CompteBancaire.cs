using Projet.Data.Entities;
using System;

/// <summary>
/// Entity of CompteBancaire
/// </summary>
public class CompteBancaire
{
    public int Id { get; set; }
    public string NumeroCompte { get; set; }
    public DateTime DateOuverture { get; set; }
    public decimal Solde { get; set; } = 1000.00m;
    public int ClientId { get; set; }
    public Client Client { get; set; }
}
