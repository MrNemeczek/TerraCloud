using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false, comment: "Gatunek zwierzęcia"),
                    DayHumidity = table.Column<int>(type: "integer", nullable: true, comment: "Wilgotność w dzień"),
                    DayTemperature = table.Column<int>(type: "integer", nullable: true, comment: "Temperatura w dzień"),
                    NightHumidity = table.Column<int>(type: "integer", nullable: true, comment: "Wilgotność w nocy"),
                    NightTemperature = table.Column<int>(type: "integer", nullable: true, comment: "Temperatura w nocy")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
