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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
