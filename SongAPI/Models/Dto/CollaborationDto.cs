namespace SongAPI.Models.Dto
{
    public class CollaborationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public bool CanAddSongs { get; set; }
        public bool CanRemoveSongs { get; set; }
    }
    public class CollaborationPutPost
    {
        public int UserId { get; set; }
        public Guid PlaylistId { get; set; }
        public bool CanAddSongs { get; set; }
        public bool CanRemoveSongs { get; set; }
    }
}
