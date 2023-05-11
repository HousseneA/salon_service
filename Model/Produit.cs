using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Produit
    {
        [Key]
        public int idProduit { get; set; }
        public String NomProduit { get; set; }
        public String imageProduit { get; set; }
        public String DescriptionProduit { get; set; }

        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
