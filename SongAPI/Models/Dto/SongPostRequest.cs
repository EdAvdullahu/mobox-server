namespace SongAPI.Models.Dto
{
    public class SongPostRequest
    {
        public SongPutPost Song { get; set; }
        public List<FeaturePutPost> Features { get; set; }
        public List<SongGenrePutPost> Genres { get; set; }
    }
}
