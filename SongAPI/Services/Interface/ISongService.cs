using SongAPI.Models.Dto;

namespace SongAPI.Services.Interface
{
    public interface ISongService
    {
        Task<ReleaseGetRequest> CreateRelease(ReleasePostRequest Release);
    }
}
