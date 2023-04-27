namespace Web.Models.Dto
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}
