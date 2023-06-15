using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface ISongStatistics
    {
        Task<AllSongsStatisticsDto> GetSongStatisticsForArtist(int artistId); 
        Task<IEnumerable<SongDateStat>> GetSongStatByDates(DateTime startDate, DateTime endDate, int songId);
    }
}
