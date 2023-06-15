namespace SongAPI.Models.Dto
{
    public class AllReleasesStatisticsDto
    {
        public int ArtistId { get; set; }
        public IEnumerable<IndividualReleaseStatisticsDto> Releases { get; set; }
    }
    public class IndividualReleaseStatisticsDto
    {
        public int ReleaseId { get; set; }
        public string ReleaseName { get; set; }
        public int NOStreams { get; set; }
        public int LMNOStreams { get; set; }
        public int LWNOStreams { get; set; }
        public int NOShares { get; set; }
    }
    public class ReleaseByDates
    {
        public IEnumerable<SongDateStat> Release { get; set; }
        public IEnumerable<SongReleaseByDate> Songs { get; set; }
    }
    public class SongReleaseByDate
    {
        public int SongID { get; set; }
        public string SongName { get; set; }
        public IEnumerable<SongDateStat> ReleaseStats { get; set; }
    }
}
