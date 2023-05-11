using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class VideoC
    {
        [Key]
        public int idVideo { get; set; }
        public String videoCategorie { get; set; }
        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
