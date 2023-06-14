namespace PodcastAPI.Models.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
        public ICollection<PodcastLike> PodcastLikes { get; set; }
    }
    public class UserPutPost
    {
        public string UserName { get; set; }
    }
    public class WhoAmI
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<PlaylistDto> Playlists { get; set; }
        public List<PodcastLike> PodcastLikes { get; set; }
        public List<PlaylistLike> PlaylistLikes { get; set; }
    }
}
