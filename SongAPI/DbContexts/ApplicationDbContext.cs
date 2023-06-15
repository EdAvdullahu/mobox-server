using Microsoft.EntityFrameworkCore;
using SongAPI.DbInitializer;
using SongAPI.Models;

namespace SongAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<GenreSong> GenreSong { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Collaboration> Collaborations { get; set; }
        public DbSet<SongLike> SongsLike { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistLike> PlaylistsLike { get; set; }
        public DbSet<PlaylistSong> PlaylistsSong { get; set; }
        public DbSet<PlaySong> Streams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasIndex(p => p.OwnerId);
            modelBuilder.Entity<Collaboration>().HasIndex(p => p.UserId);
            modelBuilder.Entity<SongLike>().HasIndex(p => p.UserId);
            modelBuilder.Entity<Artist>().HasIndex(p => p.UISId);
            modelBuilder.Entity<User>().HasIndex(p => p.UISId);
            base.OnModelCreating(modelBuilder);
            new GenreInitializer(modelBuilder).Seed();
            new ArtistInitializer(modelBuilder).Seed();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
            .HasIndex(a => a.ArtistId);
            // Index ArtistId in Features table

        modelBuilder.Entity<Feature>()
            .HasIndex(f => f.ArtistID);

        // Index ArtistId in Releases table

        modelBuilder.Entity<Release>()
            .HasIndex(r => r.ArtistId);
    }*/

    }
}
