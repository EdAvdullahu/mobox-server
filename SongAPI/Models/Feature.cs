namespace SongAPI.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}
