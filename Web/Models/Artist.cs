using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<Release> Releases { get; set; }
    }
}
