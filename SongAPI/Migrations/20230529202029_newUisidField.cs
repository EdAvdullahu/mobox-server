using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongAPI.Migrations
{
    public partial class newUisidField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UISId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UISId",
                table: "Artists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UISId",
                table: "Users",
                column: "UISId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_UISId",
                table: "Artists",
                column: "UISId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UISId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Artists_UISId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "UISId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UISId",
                table: "Artists");
        }
    }
}
