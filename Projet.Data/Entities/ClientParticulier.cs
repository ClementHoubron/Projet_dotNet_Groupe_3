using System;

/// <summary>
/// Entity of ClientParticulier
/// </summary>
public class ClientParticulier : Client
{
    public DateTime DateNaissance { get; set; }
    public string Prenom { get; set; }
    public char Sexe { get; set; }
}