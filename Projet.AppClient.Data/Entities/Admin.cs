using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Data.Entities
{
    public class Admin
    {

        [Key]
        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}
