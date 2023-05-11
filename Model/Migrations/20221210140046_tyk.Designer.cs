﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Salon_service.Model;

#nullable disable

namespace Salon_service.Model.Migrations
{
    [DbContext(typeof(tableContext))]
    [Migration("20221210140046_tyk")]
    partial class tyk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Salon_service.Model.Administrateur", b =>
                {
                    b.Property<int>("idAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAdmin"), 1L, 1);

                    b.Property<string>("EmailAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAdmin");

                    b.ToTable("Administrateurs");
                });

            modelBuilder.Entity("Salon_service.Model.AnnulationC", b =>
                {
                    b.Property<int>("idAnnulation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAnnulation"), 1L, 1);

                    b.Property<string>("AdressL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Annulation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCommand")
                        .HasColumnType("int");

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreCommande")
                        .HasColumnType("int");

                    b.Property<int>("idArticle")
                        .HasColumnType("int");

                    b.HasKey("idAnnulation");

                    b.ToTable("Annulations");
                });

            modelBuilder.Entity("Salon_service.Model.AnnulationV", b =>
                {
                    b.Property<int>("idAnnulationV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAnnulationV"), 1L, 1);

                    b.Property<DateTime>("DateRendezvous")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<int>("idRendezVous")
                        .HasColumnType("int");

                    b.Property<string>("informationComplementaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAnnulationV");

                    b.ToTable("AnnulationsV");
                });

            modelBuilder.Entity("Salon_service.Model.Article", b =>
                {
                    b.Property<int>("idArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idArticle"), 1L, 1);

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreArticle")
                        .HasColumnType("int");

                    b.Property<int>("PrixArticle")
                        .HasColumnType("int");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<int>("idProduit")
                        .HasColumnType("int");

                    b.Property<string>("imageArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idArticle");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Salon_service.Model.Categorie", b =>
                {
                    b.Property<int>("idCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategorie"), 1L, 1);

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iconCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("infoCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Salon_service.Model.Client", b =>
                {
                    b.Property<int>("idClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idClient"), 1L, 1);

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Salon_service.Model.Commentaire", b =>
                {
                    b.Property<int>("IdCommaitaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCommaitaire"), 1L, 1);

                    b.Property<string>("CommentaireCli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datepost")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCommaitaire");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Salon_service.Model.Commmande", b =>
                {
                    b.Property<int>("IdCommand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCommand"), 1L, 1);

                    b.Property<string>("AdressL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreCommande")
                        .HasColumnType("int");

                    b.Property<int>("idArticle")
                        .HasColumnType("int");

                    b.HasKey("IdCommand");

                    b.ToTable("Commmande");
                });

            modelBuilder.Entity("Salon_service.Model.Employer", b =>
                {
                    b.Property<int>("idEmployer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEmployer"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEmployer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<int>("idService")
                        .HasColumnType("int");

                    b.Property<string>("imageEmployer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEmployer");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("Salon_service.Model.Entrer", b =>
                {
                    b.Property<int>("idFournisseur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFournisseur"), 1L, 1);

                    b.Property<DateTime>("DateEntre")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreArticle")
                        .HasColumnType("int");

                    b.Property<int>("idArticle")
                        .HasColumnType("int");

                    b.HasKey("idFournisseur");

                    b.ToTable("Entrer");
                });

            modelBuilder.Entity("Salon_service.Model.IconC", b =>
                {
                    b.Property<int>("idIcon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idIcon"), 1L, 1);

                    b.Property<string>("iconCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.HasKey("idIcon");

                    b.ToTable("IconCategories");
                });

            modelBuilder.Entity("Salon_service.Model.ImageC", b =>
                {
                    b.Property<int>("idImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idImage"), 1L, 1);

                    b.Property<string>("ImageCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.HasKey("idImage");

                    b.ToTable("ImageCategories");
                });

            modelBuilder.Entity("Salon_service.Model.ImageG", b =>
                {
                    b.Property<int>("idImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idImage"), 1L, 1);

                    b.Property<string>("ImageGallery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.HasKey("idImage");

                    b.ToTable("ImageG");
                });

            modelBuilder.Entity("Salon_service.Model.InformationC", b =>
                {
                    b.Property<int>("idInformation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idInformation"), 1L, 1);

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<string>("informationCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idInformation");

                    b.ToTable("InformationCategories");
                });

            modelBuilder.Entity("Salon_service.Model.Mess", b =>
                {
                    b.Property<int>("idMess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMess"), 1L, 1);

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMess");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Salon_service.Model.Notification", b =>
                {
                    b.Property<int>("idNotification")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idNotification"), 1L, 1);

                    b.Property<int>("NombreN")
                        .HasColumnType("int");

                    b.HasKey("idNotification");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Salon_service.Model.Produit", b =>
                {
                    b.Property<int>("idProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduit"), 1L, 1);

                    b.Property<string>("DescriptionProduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<string>("imageProduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idProduit");

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("Salon_service.Model.Profil", b =>
                {
                    b.Property<int>("IdProfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfil"), 1L, 1);

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageProfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProfil");

                    b.ToTable("Profils");
                });

            modelBuilder.Entity("Salon_service.Model.Rendez_vous", b =>
                {
                    b.Property<int>("idRendezVous")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRendezVous"), 1L, 1);

                    b.Property<DateTime>("DateRendezvous")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<string>("informationComplementaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idRendezVous");

                    b.ToTable("Rendez_vous");
                });

            modelBuilder.Entity("Salon_service.Model.Service", b =>
                {
                    b.Property<int>("idService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idService"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrixService")
                        .HasColumnType("int");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<string>("imageService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idService");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Salon_service.Model.Tarif_Event", b =>
                {
                    b.Property<int>("idtarifEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idtarifEvent"), 1L, 1);

                    b.Property<string>("DescriptionTarifEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomTarifEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrixTarif")
                        .HasColumnType("int");

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<int>("idService")
                        .HasColumnType("int");

                    b.Property<string>("imageTarifEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idtarifEvent");

                    b.ToTable("Tarif_Event");
                });

            modelBuilder.Entity("Salon_service.Model.VideoC", b =>
                {
                    b.Property<int>("idVideo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVideo"), 1L, 1);

                    b.Property<int>("idCategorie")
                        .HasColumnType("int");

                    b.Property<string>("videoCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVideo");

                    b.ToTable("videoCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
