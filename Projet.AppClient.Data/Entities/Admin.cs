using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Projet.AppClient.Data.Entities
{
    public class Admin
    {
        [Key]
        public string Login { get; set; }
        public string MotDePasse { get; set; }

        public void SetPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                MotDePasse = Convert.ToBase64String(hash);
            }
        }
    }
}
