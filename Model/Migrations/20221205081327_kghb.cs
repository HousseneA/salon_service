using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_service.Model.Migrations
{
    public partial class kghb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annulations",
                columns: table => new
                {
                    idAnnulation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCommand = table.Column<int>(type: "int", nullable: false),
                    EmailClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomArticle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCommande = table.Column<int>(type: "int", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idArticle = table.Column<int>(type: "int", nullable: false),
                    Annulation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annulations", x => x.idAnnulation);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annulations");
        }
    }
}
