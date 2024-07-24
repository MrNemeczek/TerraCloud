﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasurementInDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMeasurement",
                table: "UserDevice");

            migrationBuilder.DropColumn(
                name: "MeasurementTime",
                table: "UserDevice");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMeasurement",
                table: "Device",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Ostatnia data pomiaru");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementTime",
                table: "Device",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Okres czasu co jaki urządzenie ma zbierać pomiary wyrażony w minutach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMeasurement",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "MeasurementTime",
                table: "Device");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMeasurement",
                table: "UserDevice",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Ostatnia data pomiaru");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementTime",
                table: "UserDevice",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Okres czasu co jaki urządzenie ma zbierać pomiary wyrażony w minutach");
        }
    }
}
