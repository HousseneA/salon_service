﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_service.Model
{
    public class Cls
    {
        [Key]
        public int idArticle { get; set; }
        public String NomArticle { get; set; }
        public int PrixArticle { get; set; }
        public int NombreArticle { get; set; }
        public String imageArticle { get; set; }
        public int idProduit { get; set; }
        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
