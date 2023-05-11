using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_service.Model.Migrations
{
    public partial class tyk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnulationsV",
                columns: table => new
                {
                    idAnnulationV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRendezVous = table.Column<int>(type: "int", nullable: false),
                    NomClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRendezvous = table.Column<DateTime>(type: "datetime2", nullable: false),
                    informationComplementaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCategorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnulationsV", x => x.idAnnulationV);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnulationsV");
        }
    }
}
