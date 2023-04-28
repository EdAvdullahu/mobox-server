namespace PodcastAPI.Models.Dto
{
    public class PodcastGenreDto
    {
        public int Id { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class PodcastGenrePutPost {
        public int PodcastId { get; set; }
        public int GenreId { get; set; }

    }

}
