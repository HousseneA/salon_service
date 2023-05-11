using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Client
    {
        [Key]
        public int idClient { get; set; }
        public String NomClient { get; set; }
        public String EmailClient { get; set; }
        public String PasswordClient { get; set; }
      
      
    }
}
