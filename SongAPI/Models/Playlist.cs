using System.ComponentModel.DataAnnotations;

namespace SongAPI.Models
{
    public class Playlist
    {
        [Key]
        public Guid PlaylitId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistSong> Songs { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
    }
}
