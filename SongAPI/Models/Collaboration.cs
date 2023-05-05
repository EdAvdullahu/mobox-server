using System.Text.Json.Serialization;

namespace SongAPI.Models
{
    public class Collaboration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid PlaylistId { get; set; }
        [JsonIgnore]
        public Playlist Playlist { get; set; }
        public bool CanAddSongs { get; set; }
        public bool CanRemoveSongs { get; set; }
    }
}
