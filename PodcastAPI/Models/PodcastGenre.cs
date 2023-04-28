namespace PodcastAPI.Models
{
    public class PodcastGenre
    {
        public int Id { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
