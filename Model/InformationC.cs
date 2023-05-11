using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class InformationC
    {
        [Key]
        public int idInformation { get; set; }
        public String informationCategorie { get; set; }

        public int idCategorie { get; set; }
    }
}
