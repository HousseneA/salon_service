using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_service.Model.Migrations
{
    public partial class yu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MontantCommande",
                table: "Commmande",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantCommande",
                table: "Commmande");
        }
    }
}
