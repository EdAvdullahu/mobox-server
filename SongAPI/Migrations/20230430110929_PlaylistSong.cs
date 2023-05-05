using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongAPI.Migrations
{
    public partial class PlaylistSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_PlaylistPlaylitId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistPlaylitId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistPlaylitId",
                table: "Songs");

            migrationBuilder.CreateTable(
                name: "PlaylistsSong",
                columns: table => new
                {
                    PlaySongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistsSong", x => x.PlaySongId);
                    table.ForeignKey(
                        name: "FK_PlaylistsSong_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "PlaylitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistsSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSong_PlaylistId",
                table: "PlaylistsSong",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSong_SongId",
                table: "PlaylistsSong",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistsSong");

            migrationBuilder.AddColumn<Guid>(
                name: "PlaylistPlaylitId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistPlaylitId",
                table: "Songs",
                column: "PlaylistPlaylitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_PlaylistPlaylitId",
                table: "Songs",
                column: "PlaylistPlaylitId",
                principalTable: "Playlists",
                principalColumn: "PlaylitId");
        }
    }
}
