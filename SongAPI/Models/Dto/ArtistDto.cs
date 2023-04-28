namespace SongAPI.Models.Dto
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}
