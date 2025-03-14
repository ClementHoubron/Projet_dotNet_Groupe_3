﻿using Projet.AppClient.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace Projet.AppClient.Service
{ 
    public abstract class ClientDto
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage="Nom requis.")]
        public string Nom { get; set; }


        public int AdressePostaleId { get; set; }

        [Required(ErrorMessage="Adresse requise.")]
        public AdresseParticulier AdressePostale { get; set; }

        public string? Email { get; set; }
        public ICollection<CompteBancaire> ComptesBancaires { get; set; }

        public override string ToString()
        {
            // return $"{Id:000} {Nom} {AdressePostale.ToString()} {Email}";
            return $"{Id:000} {Nom} {AdressePostale.ToString()} {Email}";
        }
    }
}