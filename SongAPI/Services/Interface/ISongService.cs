using SongAPI.Models;
using SongAPI.Models.Dto;

namespace SongAPI.Services.Interface
{
    public interface ISongService
    {
        Task<ReleaseDto> CreateRelease(ReleasePostRequest Release);
        Task<SongGetRequest> CreateSong(SongPostRequest SongRequest);
    }
}
