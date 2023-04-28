using PodcastAPI.Models.Dto;

namespace PodcastAPI.Repository.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<GenreDto> GetGenreByID(int Id);
        Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto);
        Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto, int id);
        Task<bool> DeleteGenre(int Id);
    }
}
