using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class SongGenre
    {
        [Key]
        public int SongGenreId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Disposable { get; set; }
    }
}
