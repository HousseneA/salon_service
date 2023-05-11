using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Profil
    {
        [Key]
        public int IdProfil { get; set; }
        public String EmailClient { get; set; }
        public String imageProfil { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
