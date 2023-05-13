using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LyricsAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongApiId = table.Column<int>(type: "int", nullable: false),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.CreateTable(
                name: "Lyrics",
                columns: table => new
                {
                    LyricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lyrics", x => x.LyricId);
                    table.ForeignKey(
                        name: "FK_Lyrics_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verses",
                columns: table => new
                {
                    VerseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Annotated = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AnnotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LyricId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verses", x => x.VerseId);
                    table.ForeignKey(
                        name: "FK_Verses_Lyrics_LyricId",
                        column: x => x.LyricId,
                        principalTable: "Lyrics",
                        principalColumn: "LyricId");
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    AnnotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnotationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.AnnotationId);
                    table.ForeignKey(
                        name: "FK_Annotations_Verses_VerseId",
                        column: x => x.VerseId,
                        principalTable: "Verses",
                        principalColumn: "VerseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_VerseId",
                table: "Annotations",
                column: "VerseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lyrics_SongId",
                table: "Lyrics",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SongApiId",
                table: "Songs",
                column: "SongApiId");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_LyricId",
                table: "Verses",
                column: "LyricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "Verses");

            migrationBuilder.DropTable(
                name: "Lyrics");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
