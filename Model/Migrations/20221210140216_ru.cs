using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_service.Model.Migrations
{
    public partial class ru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Annulation",
                table: "AnnulationsV",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annulation",
                table: "AnnulationsV");
        }
    }
}
