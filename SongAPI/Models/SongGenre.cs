using System.ComponentModel.DataAnnotations;

namespace SongAPI.Models
{
    public class SongGenre
    {
        [Key]
        public int SongGenreId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
