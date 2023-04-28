namespace SongAPI.Models.Dto
{
    public class ArtistPutPost
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
