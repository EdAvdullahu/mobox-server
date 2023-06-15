using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongAPI.Migrations
{
    public partial class Streams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    ListenDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streams_SongId",
                table: "Streams",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_UserId",
                table: "Streams",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streams");
        }
    }
}
