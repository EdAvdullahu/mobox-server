namespace SongAPI.Models.Dto
{
    public class AllSongsStatisticsDto
    {
        public int ArtistId { get; set; }
        public IEnumerable<IndividualStatisticsDto> Songs { get; set;}
    }
    public class IndividualStatisticsDto
    {
        public int SongId { get; set; }
        public int ReleaseId { get; set; }
        public string ReleaseName { get; set; }
        public string SongName { get; set; }
        public int NOStreams { get; set; }
        public int LWNOStreams { get; set; }
        public int NOLikes { get; set; }
    }
    public class SongDateStat
    {
        public int NOStreams { get; set; }
        public DateTime Date { get; set; }
    }
}
