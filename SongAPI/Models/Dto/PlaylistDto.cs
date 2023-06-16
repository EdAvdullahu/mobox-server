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
        public ICollection<PlaylistSong> Songs { get; set; }
        public int LikesCount { get; set; }
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
    public class SongPlaylistDto
    {
        public int PlaySongId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }

    public class HasReadWritePerm
    {
        public int UserId { get; set; }
        public Guid PlaylistId { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAdd { get; set; }
    }
    
}
