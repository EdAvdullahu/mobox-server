using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface ISongService
    {
        Task<T> GetSongs<T>(string token);
        Task<T> GetSongById<T>(int SongId, string token);
        Task<T> CreateUpdateSong<T>(SongPutPost songDto, string token);
        Task<T> CreateUpdateSong<T>(SongPutPost songDto, int id,string token);
        Task<T> DeleteSong<T>(int SongId, string token);
    }
}
