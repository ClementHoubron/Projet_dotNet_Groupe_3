﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Data.Entities
{
    public class Adresse
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public override string ToString()
        {
            return $"{Libelle} {Complement} {CodePostal} {Ville}";
        }
    }
    }
