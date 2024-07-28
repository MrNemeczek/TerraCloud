using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceAnimalUserNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalUserId",
                table: "Device",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device",
                column: "AnimalUserId",
                principalTable: "AnimalUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalUserId",
                table: "Device",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AnimalUser_AnimalUserId",
                table: "Device",
                column: "AnimalUserId",
                principalTable: "AnimalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
