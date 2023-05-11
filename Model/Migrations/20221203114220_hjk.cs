using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_service.Model.Migrations
{
    public partial class hjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Entrer",
                columns: table => new
                {
                    idFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idArticle = table.Column<int>(type: "int", nullable: false),
                    NomArticle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreArticle = table.Column<int>(type: "int", nullable: false),
                    DateEntre = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrer", x => x.idFournisseur);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Entrer");

            
        }
    }
}
