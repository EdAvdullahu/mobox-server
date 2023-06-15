namespace SongAPI.Models.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Guid UISId { get; set; }
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
        public ICollection<SongLike> SongLikes { get; set; }
    }
    public class UserPutPost
    {
        public string UserName { get; set; }
        public Guid UISId { get; set; }
    }
    public class WhoAmI
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Guid UISId { get; set; }
        public List<PlaylistDto> Playlists { get; set; }
        public List<SongLike> SongLikes { get; set; }
        public List<PlaylistLike> PlaylistLikes { get; set; }
    }
}
