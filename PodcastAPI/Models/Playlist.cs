using System.ComponentModel.DataAnnotations;

namespace PodcastAPI.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
        public ICollection<PlaylistPodcast> Podcasts { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
    }
}
