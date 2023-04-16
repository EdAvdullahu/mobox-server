using Microsoft.EntityFrameworkCore;
using SongAPI.Models;

namespace SongAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        /*public DbSet<SongGenre> SongGenres { get; set; }*/
        /*public DbSet<Feature> Features { get; set; }*/
        public DbSet<Release> Releases { get; set; }
    }
}
