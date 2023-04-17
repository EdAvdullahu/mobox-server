using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<GenreDto> GetGenreByID(int GenreId);
        Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto);
        Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto, int id);
        Task<bool> DeleteGenre(int GenreId);
    }
}
