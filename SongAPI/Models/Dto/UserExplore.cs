namespace SongAPI.Models.Dto
{
    public class UserExplore
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public Song TrendingSong { get; set; }
        public IEnumerable<ArtistDto> TrendingArtist { get; set; }
        public IEnumerable<Song> MostPlayed { get; set; }
    }
}
