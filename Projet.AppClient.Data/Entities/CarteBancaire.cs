using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Data.Entities
{
    public class CarteBancaire
    {
        [Key]
        [Required]
        public string NumeroCarte { get; set; }

        public string CompteBancaireNumeroCompte { get; set; }

        public CompteBancaire CompteBancaire { get; set; }
    }
}
