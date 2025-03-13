using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Service
{
    public class AdresseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adresse incomplète.")]
        public string Libelle { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Adresse incomplète.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Adresse incomplète.")]
        public string Ville { get; set; }
    }
}
