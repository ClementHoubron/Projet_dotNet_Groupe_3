using Projet.AppClient.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace Projet.AppClient.Service
{ 
    public abstract class AdminDto
    {

        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}