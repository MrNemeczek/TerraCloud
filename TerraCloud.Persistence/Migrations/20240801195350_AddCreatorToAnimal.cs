using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorToAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animal_UserId",
                table: "Animal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_User_UserId",
                table: "Animal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_User_UserId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_UserId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Animal");
        }
    }
}
