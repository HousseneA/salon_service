using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Categorie
    {

        [Key]
        public int idCategorie { get; set; }
        public String typeCategorie { get; set; }
        public String NomCategorie { get; set; }
        public String iconCategorie { get; set; }
        public String infoCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
