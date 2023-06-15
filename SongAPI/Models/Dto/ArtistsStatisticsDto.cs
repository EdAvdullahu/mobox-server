namespace SongAPI.Models.Dto
{
    public class ArtistsStatisticsDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int NOStreams { get; set; }
        public int ALLStreams { get; set; }
        public int MOListeners { get; set; }
        public int ALListeners { get; set; }
        public int NOLikes { get; set; }
        public int ALLLikes { get; set; }
    }

    public class TopListenersDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<ListenerDto> TopListeners{ get; set;}
    }   

    public class ListenerDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int NOStreams { get; set; }
        public int NOLikes { get; set; }
    }
}
