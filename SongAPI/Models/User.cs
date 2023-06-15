using System.ComponentModel.DataAnnotations;

namespace SongAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public Guid UISId { get; set; }
        public string UserName { get; set; }
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
        public ICollection<SongLike> SongLikes { get; set; }
        public ICollection<PlaySong> Streams { get; set; }
    }
}
