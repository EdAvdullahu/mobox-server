using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IReleaseStatistics
    {
        Task<AllReleasesStatisticsDto> GetReleaseStatisticsForArtist(int artistId);
        Task<ReleaseByDates> GetReleaseStatByDates(DateTime startDate, DateTime endDate, int songId);
    }
}
