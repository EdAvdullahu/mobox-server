namespace SongAPI.Models.Dto
{
    public class PlaylistDto
    {
        public Guid PlaylitId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
        public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
    }
    public class PlaylistPutPost
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
    }
    public class SongPlaylistPutPost
    {
        public Guid PlaylistId { get; set; }
        public int SongId { get; set; }
    }
    
}
