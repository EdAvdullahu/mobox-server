using LyricsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LyricsAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Lyric> Lyrics { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasIndex(l => l.SongApiId);
            modelBuilder.Entity<Verse>()
                .HasOne(v => v.Annotation)
                .WithOne(a => a.Verse)
                .HasForeignKey<Annotation>(a => a.VerseId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
