namespace PodcastAPI.Models.Dto
{   
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PodcastDto> Podcasts { get; set; } 
    }

    public class ArtistPutPost
    {
        public string Name { get; set; }
        public ICollection<PodcastDto> Podcasts { get; set; }

    }
}
