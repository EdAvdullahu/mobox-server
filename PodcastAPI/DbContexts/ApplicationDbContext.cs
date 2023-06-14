using Microsoft.EntityFrameworkCore;
using PodcastAPI.DbInitializer;
using PodcastAPI.Models;

namespace PodcastAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<PodcastGenre> PodcastGenres { get; set; }
        public DbSet<PodcastLike> PodcastLikes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistPodcast> PlaylistPodcasts { get; set; }
        public DbSet<PlaylistLike> PlaylistsLike { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Playlist>().HasIndex(p => p.OwnerId);
        //    modelBuilder.Entity<PodcastLike>().HasIndex(p => p.UserId);
        //    base.OnModelCreating(modelBuilder);
        //    new GenreInitializer(modelBuilder).Seed();
        //    new ArtistInitializer(modelBuilder).Seed();
        //}

    }
}
