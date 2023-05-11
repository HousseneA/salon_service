using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Salon_service.Model;
namespace Salon_service.Model
{
    public class tableC1 : DbContext
    {
        public tableC1(DbContextOptions<tableC1> options) : base(options)
        { 
        
        }
            public DbSet<Article1> Article { get; set; }
        }
}

