using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_service.Model
{
    public class Administrateur
    {
        [Key]
        public int idAdmin { get; set; }
        public String NomAdmin { get; set; }
        public String EmailAdmin { get; set; }
        public String PasswordAdmin { get; set; }
        
    }
}
