using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Mess
    {
        [Key]
        public int idMess { get; set; }
        public String NomClient { get; set; }
        public String EmailClient { get; set; }
        public String objet { get; set; }
        public String Message { get; set; }

    }
}
