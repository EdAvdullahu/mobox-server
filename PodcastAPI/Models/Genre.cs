using System.ComponentModel.DataAnnotations;

namespace PodcastAPI.Models
{
    public class Genre
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PodcastGenre> Podcasts { get; set; }
    }
}
