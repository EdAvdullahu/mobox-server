namespace LyricsAPI.Models.Dto
{
    public class LyricDto
    {
        public Guid LyricId { get; set; }
        public Guid SongId { get; set; }
        public Song Song { get; set; }
        public ICollection<Verse> Verses { get; set; }
    }
    public class LyricPut
    {
        public Guid SongId { get; set; }
        public IList<VersePost> Verses { get; set; }
    }
}
