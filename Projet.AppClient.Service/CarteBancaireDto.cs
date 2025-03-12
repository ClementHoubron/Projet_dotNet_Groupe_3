using Projet.AppClient.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Service
{
    public class CarteBancaireDto
    {
        public string NumeroCarte { get; set; }

        public string CompteBancaireNumeroCompte { get; set; }

        public CompteBancaire CompteBancaire { get; set; }
    }
}
