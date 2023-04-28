using Microsoft.EntityFrameworkCore;
using PodcastAPI.Models;

namespace PodcastAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }

    }
}
