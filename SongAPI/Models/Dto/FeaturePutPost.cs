namespace SongAPI.Models.Dto
{
    public class FeaturePutPost
    {
        public int SongId { get; set; }
        public int ArtistID { get; set; }
        public FeatureRole FeatureRole { get; set; }
    }
}
