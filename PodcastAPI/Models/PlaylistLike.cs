namespace PodcastAPI.Models
{
    public class PlaylistLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
}
