using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceChangeLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserDevice",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Nazwa urządzenia dla konretnego użytkownika");

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "Device",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Unikalny kod urządzenia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserDevice");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Device",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Nazwa urządzenia");
        }
    }
}
