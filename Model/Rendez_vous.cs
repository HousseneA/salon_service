using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Rendez_vous
    {

        [Key]
        public int idRendezVous { get; set; }
      
        public String NomClient { get; set; }
        public String EmailClient { get; set; }
        public String Motif { get; set; }
        public DateTime DateRendezvous { get; set; }
        public String informationComplementaire { get; set; }
        public int idCategorie { get; set; }
    }
}
