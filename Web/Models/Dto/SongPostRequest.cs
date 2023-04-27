namespace Web.Models.Dto
{
    public class SongPostRequest
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public bool HasFeatures { get; set; }
        public int ReleaseId { get; set; }
        public bool IsExplicite { get; set; }
        public IFormFile Audio { get; set; }
        public List<FeaturePutPost> Features { get; set; } = new List<FeaturePutPost>();
        public List<SongGenrePutPost> Genres { get; set; } = new List<SongGenrePutPost>();
    }
}
