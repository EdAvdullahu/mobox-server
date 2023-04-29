namespace SongAPI.Models.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
        public ICollection<SongLike> SongLikes { get; set; }
    }
    public class UserPutPost
    {
        public string UserName { get; set; }
    }
}
