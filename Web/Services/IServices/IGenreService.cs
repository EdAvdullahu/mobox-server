using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface IGenreService
    {
        Task<T> GetGenres<T>(string token);
        Task<T> GetGenreByID<T>(int GenreId,string token);
        Task<T> CreateUpdateGenre<T>(GenrePutPost GenreDto,string token);
        Task<T> CreateUpdateGenre<T>(GenrePutPost GenreDto, int id,string token);
        Task<T> DeleteGenre<T>(int GenreId, string token);
    }
}
