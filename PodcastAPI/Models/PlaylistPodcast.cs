using System.ComponentModel.DataAnnotations;

namespace PodcastAPI.Models
{
    public class PlaylistPodcast
    {
        [Key]
        public int Id { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }

        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
