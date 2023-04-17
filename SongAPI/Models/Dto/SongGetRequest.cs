namespace SongAPI.Models.Dto
{
    public class SongGetRequest
    {
        public SongDto Song { get; set; }
        public List<FeatureDto> Features { get; set; }
        public List<SongGenreDto> Genres { get; set; }
    }
}
