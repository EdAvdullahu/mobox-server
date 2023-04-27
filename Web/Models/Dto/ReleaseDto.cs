namespace Web.Models.Dto
{
    public class ReleaseDto
    {
        public int ReleaseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ReleaseType ReleaseType { get; set; }
    }
}

