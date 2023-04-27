namespace Web.Models.Dto
{
    public class SongPutPost
    {
        public string Name { get; set; }
        public int LengthInSec { get; set; }
        public string ImageUrl { get; set; }
        public bool HasFeatures { get; set; }
        public int ReleaseId { get; set; }
        public bool IsExplicite { get; set; }
        public string Path { get; set; }
    }
}
