using System.ComponentModel.DataAnnotations;

namespace PodcastAPI.Models
{
    public class Artist
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Podcast> Podcasts { get; set;} = new List<Podcast>();
    }
}
