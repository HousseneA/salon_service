using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Entrer
    {
        [Key]
        public int idFournisseur { get; set; }
        public int idArticle { get; set; }
        public String NomArticle { get; set; }
        public int NombreArticle { get; set; }
        public DateTime DateEntre { get; set; }
    }
}
