namespace Web.Models.Dto
{
    public class FeatureDto
    {
        public int FeatureId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public FeatureRole FeatureRole { get; set; }
    }
    public enum FeatureRole
    {
        MAIN,
        FEATURE
    }
}
