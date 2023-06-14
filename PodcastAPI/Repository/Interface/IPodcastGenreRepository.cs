using PodcastAPI.Models.Dto;

namespace PodcastAPI.Repository.Interface
{
    public interface IPodcastGenreRepository
    {
        Task<IEnumerable<PodcastGenreDto>> GetPodcastGenresForPodcast(int PodcastId);
        Task<IEnumerable<PodcastGenreDto>> GetPodcastsWithGenre(int GenreId);
        Task<PodcastGenreDto> AddGenre(PodcastGenrePutPost GenreDto);
        Task<bool> DeleteGenre(int GenreId);
    }
}
