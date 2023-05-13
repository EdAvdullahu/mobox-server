using System.ComponentModel.DataAnnotations;

namespace LyricsAPI.Models
{
    public class Lyric
    {
        [Key]
        public Guid LyricId { get; set; }
        public Guid SongId { get; set; }
        public Song Song { get; set; }
        public ICollection<Verse> Verses { get; set; }
    }
}
