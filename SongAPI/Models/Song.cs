using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SongAPI.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public string ImageUrl { get; set; }
        /*public int ArtistId { get; set; }
        public Artist Artist { get; set; }*/
        public bool HasFeatures { get; set; }
        public ICollection<Feature> Features { get; set; } 
        public ICollection<GenreSong> Genres { get; set; }
        public int? ReleaseId { get; set; }
        public Release Release { get; set; }
        public bool IsExplicite { get; set; }
        public string Path { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
