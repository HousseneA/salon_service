using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_service.Model
{
    public class ImageG
    {
        [Key]
        public int idImage { get; set; }
        public String ImageGallery { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public int idCategorie { get; set; }
    }
}
