using System.ComponentModel.DataAnnotations;

namespace LyricsAPI.Models
{
    public class Song
    {
        [Key]
        public Guid SongId { get; set; }
        public int SongApiId { get; set; }
        public string SongName { get; set; }
    }
}
