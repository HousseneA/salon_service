using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Salon_service.Model
{
    public class Commentaire
    {
        [Key]
        public int IdCommaitaire { get; set; }
        public String EmailClient { get; set; }
        public DateTime datepost { get; set; }
        public String CommentaireCli { get; set; }
  
    }
}
