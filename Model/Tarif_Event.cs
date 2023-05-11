using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Tarif_Event
    {
        [Key]
        public int idtarifEvent { get; set; }
        public String NomTarifEvent { get; set; }
        public String DescriptionTarifEvent { get; set; }
        public String imageTarifEvent { get; set; }

        public int PrixTarif { get; set; }
        public int idService { get; set; }
        public int idCategorie { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
