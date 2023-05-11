using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Salon_service.Model
{
    public class Notification
    {
        [Key]
        public int idNotification { get; set; }
        public int NombreN { get; set; }
    }
}
