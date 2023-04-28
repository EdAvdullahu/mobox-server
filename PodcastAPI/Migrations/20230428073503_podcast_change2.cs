using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PodcastAPI.Migrations
{
    public partial class podcast_change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Podcasts_PodcastId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_Artists_PodcasterId",
                table: "Podcasts");

            migrationBuilder.DropIndex(
                name: "IX_Podcasts_PodcasterId",
                table: "Podcasts");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "ArtistPodcast",
                columns: table => new
                {
                    FeaturedId = table.Column<int>(type: "int", nullable: false),
                    PodcastsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistPodcast", x => new { x.FeaturedId, x.PodcastsId });
                    table.ForeignKey(
                        name: "FK_ArtistPodcast_Artists_FeaturedId",
                        column: x => x.FeaturedId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistPodcast_Podcasts_PodcastsId",
                        column: x => x.PodcastsId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistPodcast_PodcastsId",
                table: "ArtistPodcast",
                column: "PodcastsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistPodcast");

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_PodcasterId",
                table: "Podcasts",
                column: "PodcasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PodcastId",
                table: "Artists",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Podcasts_PodcastId",
                table: "Artists",
                column: "PodcastId",
                principalTable: "Podcasts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_Artists_PodcasterId",
                table: "Podcasts",
                column: "PodcasterId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
