using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LyricsAPI.Migrations
{
    public partial class initialMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Lyrics_LyricId",
                table: "Verses");

            migrationBuilder.AlterColumn<Guid>(
                name: "LyricId",
                table: "Verses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Lyrics_LyricId",
                table: "Verses",
                column: "LyricId",
                principalTable: "Lyrics",
                principalColumn: "LyricId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Lyrics_LyricId",
                table: "Verses");

            migrationBuilder.AlterColumn<Guid>(
                name: "LyricId",
                table: "Verses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Lyrics_LyricId",
                table: "Verses",
                column: "LyricId",
                principalTable: "Lyrics",
                principalColumn: "LyricId");
        }
    }
}
