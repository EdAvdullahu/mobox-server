namespace SongAPI.Models.Dto
{
    public class PlaylistLikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
    public class PlaylistLikePutPost
    {
        public int UserId { get; set; }
        public Guid PlaylistId { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
}
