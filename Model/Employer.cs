using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Employer
    {
        [Key]
        public int idEmployer { get; set; }
        public String NomEmployer { get; set; }
        public String Facebook { get; set; }
        public String Linkedin { get; set; }
        public String Email { get; set; }
        public String Titre { get; set; }
        public String imageEmployer { get; set; }
        public int idService { get; set; }
        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
