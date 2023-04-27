using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface ISongGenreService
    {
        Task<T> GetSongGenresForSong<T>(int SongId, string token);
        Task<T> GetSongsWithGenre<T>(int GenreId, string token);
        Task<T> AddGenre<T>(SongGenrePutPost GenreDto, string token);
        Task<T> DeleteFeature<T>(int GenreId, string token);
    }
}
