using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceMonitorsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceMonitor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "TimeStamp"),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Czas pobrania pomiaru"),
                    Humidity = table.Column<int>(type: "integer", nullable: true, comment: "Pomiar wilgotności"),
                    Temperature = table.Column<int>(type: "integer", nullable: true, comment: "Pomiar temperatury"),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceMonitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceMonitor_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceMonitor_DeviceId",
                table: "DeviceMonitor",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceMonitor");
        }
    }
}
