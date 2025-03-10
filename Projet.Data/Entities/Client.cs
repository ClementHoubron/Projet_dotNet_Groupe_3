using System;

/// <summary>
/// Entity of Client
/// </summary>
public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string AdressePostale { get; set; }
    public string Email { get; set; }
    public List<CompteBancaire> Comptes { get; set; } = new List<CompteBancaire>();
}
