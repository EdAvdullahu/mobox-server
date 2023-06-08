using System.ComponentModel.DataAnnotations;

namespace PodcastAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // me bo qitu id ma mir sesa userID
        public string UserName { get; set; }
        //public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistLike> PlaylistLikes { get; set; }
        public ICollection<PodcastLike> PodcastLikes { get; set; }
    }
}
