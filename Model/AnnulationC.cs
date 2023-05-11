using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class AnnulationC
    {
        [Key]
        public int idAnnulation { get; set; }
        public int IdCommand { get; set; }
        public String EmailClient { get; set; }
        public String NomArticle { get; set; }
        public String AdressL { get; set; }
        public int NombreCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public int idArticle { get; set; }
        public DateTime Annulation { get; set; }
    }
}
