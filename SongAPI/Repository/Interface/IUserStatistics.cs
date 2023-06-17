using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IUserStatistics
    {
        Task<ArtistsStatisticsDto> GetStatisticsForArtist(int artistId);
        Task<TopListenersDto> GetTopListeners (int artistId);
        Task<IEnumerable<ArtistDto>> GetTrendingArtists();
    }
}
