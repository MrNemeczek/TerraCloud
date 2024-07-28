using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AnimalDeviceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AnimalUserId",
                table: "Device",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "DayHumidity",
                table: "Device",
                type: "integer",
                nullable: true,
                comment: "Wilgotność w dzień");

            migrationBuilder.AddColumn<int>(
                name: "DayTemperature",
                table: "Device",
                type: "integer",
                nullable: true,
                comment: "Temperatura w dzień");

            migrationBuilder.AddColumn<int>(
                name: "NightHumidity",
                table: "Device",
                type: "integer",
                nullable: true,
                comment: "Wilgotność w nocy");

            migrationBuilder.AddColumn<int>(
                name: "NightTemperature",
                table: "Device",
                type: "integer",
                nullable: true,
                comment: "Temperatura w nocy");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Animal",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Czy gatunek jest dostępny publicznie");

            migrationBuilder.CreateTable(
                name: "AnimalUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalUser_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_AnimalUserId",
                table: "Device",
                column: "AnimalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUser_AnimalId",
                table: "AnimalUser",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUser_UserId",
                table: "AnimalUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device",
                column: "AnimalUserId",
                principalTable: "AnimalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device");

            migrationBuilder.DropTable(
                name: "AnimalUser");

            migrationBuilder.DropIndex(
                name: "IX_Device_AnimalUserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "AnimalUserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DayHumidity",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DayTemperature",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "NightHumidity",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "NightTemperature",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Animal");
        }
    }
}
