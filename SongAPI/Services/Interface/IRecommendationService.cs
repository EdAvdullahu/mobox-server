using SongAPI.Models;

namespace SongAPI.Services.Interface
{
    public interface IRecommendationService
    {
        Task<dynamic> GetRecommendations(Guid playlistId);
    }
}
