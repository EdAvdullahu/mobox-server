

namespace PodcastAPI.Models
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PodcasterId { get; set; }
        public List<Artist>? Featured { get; set; } = new List<Artist>();
        public TimeSpan Length { get; set; }
        public List<PodcastGenre>? Genres { get; set; } = new List<PodcastGenre>();
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        //qito dyja per foto
        public string PictureUrl { get; set; }
        public string CloudanaryPublicId { get; set; }

        //qito dyja per Muzik
        public string Mp3Url { get; set; }
        public string CloudanaryPublicMp3Id { get; set; }

    }
}
/*
 * 
Title
Main Artist (Podcaster)
featured Artists list
Length
Genres
Release Date
Image
Mp3
*
 */