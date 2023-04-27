namespace Web.Models.Dto
{
    public class ReleasePostRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public IFormFile Image { get; set; }
        public int NumnerOfSongs { get; set; }
    }
}
