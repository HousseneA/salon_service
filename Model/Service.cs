using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Service
    {
        [Key]
        public int idService { get; set; }
        public String NomService { get; set; }
        public String Description { get; set; }
        public String imageService { get; set; }
        public int PrixService { get; set; }
        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
