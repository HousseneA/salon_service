using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Salon_service.Model;
namespace Salon_service.Model
{
    public class tableContext : DbContext
    {
        public tableContext(DbContextOptions<tableContext> options) : base(options)
        {

        }
        public DbSet<Categorie> Categories { get; set; }
       
        public DbSet<IconC> IconCategories { get; set; }
        public DbSet<ImageC> ImageCategories { get; set; }
        public DbSet<InformationC> InformationCategories { get; set; }
        public DbSet<VideoC> videoCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Mess> Messages { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Salon_service.Model.Produit> Produit { get; set; }
        public DbSet<Salon_service.Model.Article> Article { get; set; }
        public DbSet<AnnulationC> Annulations { get; set; }
        public DbSet<AnnulationV> AnnulationsV { get; set; }
        public DbSet<Salon_service.Model.Commmande> Commmande { get; set; }
        public DbSet<Salon_service.Model.Entrer> Entrer { get; set; }
        public DbSet<Salon_service.Model.Service> Service { get; set; }
        public DbSet<Salon_service.Model.Employer> Employer { get; set; }
        public DbSet<Salon_service.Model.Tarif_Event> Tarif_Event { get; set; }
        public DbSet<Salon_service.Model.Rendez_vous> Rendez_vous { get; set; }
        public DbSet<Salon_service.Model.ImageG> ImageG { get; set; }
        public DbSet<Salon_service.Model.Notification> Notifications { get; set; }
        public DbSet<Salon_service.Model.Cls> Cls { get; set; }
    }
}
