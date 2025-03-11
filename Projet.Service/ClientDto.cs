using Projet.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace Projet.Service
{ 
    public abstract class ClientDto
    {
       
        public int Id { get; set; }

        public string Nom { get; set; }

        public int AdressePostaleId { get; set; }
        public AdresseParticulier AdressePostale { get; set; }

        public string Email { get; set; }
        public List<CompteBancaire> Comptes { get; set; } = new List<CompteBancaire>();
    }
}