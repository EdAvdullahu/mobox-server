namespace SongAPI.Models.Dto
{
    public class ReleasePutPost
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ReleaseType ReleaseType { get; set; }
    }
}
