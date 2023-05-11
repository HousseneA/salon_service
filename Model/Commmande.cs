using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Commmande
    {
        [Key]
        public int IdCommand { get; set; }
        public String EmailClient { get; set; }
        public String NomArticle { get; set; }
        public String AdressL { get; set; }
        public int NombreCommande { get; set; }
        public int MontantCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public int idArticle { get; set; }



    }
}
