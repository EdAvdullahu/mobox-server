using System.ComponentModel.DataAnnotations;

namespace SongAPI.Models
{
    public class PlaylistSong
    {
        [Key]
        public int PlaySongId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }

        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
