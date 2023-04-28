namespace PodcastAPI.Models.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GenrePutPost
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
