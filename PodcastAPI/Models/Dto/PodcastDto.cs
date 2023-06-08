using PodcastAPI.Models;
using System.ComponentModel;

namespace PodcastAPI.Models.Dto
{
    public class PodcastDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LengthInSec { get; set; }
        public int PodcasterId { get; set; }
        public Artist Podcaster { get; set; }
        public string Features { get; set; }
        public TimeSpan Length { get; set; }
        public ICollection<PodcastGenreDto> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PictureUrl { get; set; }
        public string Mp3Url { get; set; }



    }
    public class PodcastPutPost
    {
        public string Title { get; set; }
        public int LengthInSec { get; set; }

        public int PodcasterId { get; set; }
        public Artist Podcaster { get; set; }
        public string Features { get; set; }
        public ICollection<PodcastGenreDto> Genres { get; set; }
        [DefaultValue(typeof(DateTime), "")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public IFormFile Image { get; set; }
        public IFormFile Mp3 { get; set; }

    }

    public class PodcastDel
    {
        public int Id { get; set; }
        //qito dyja per foto
        public string PictureUrl { get; set; }
        public string CloudanaryPublicId { get; set; }

        //qito dyja per Muzik
        public string Mp3Url { get; set; }
        public string CloudanaryPublicMp3Id { get; set; }
    }

}
