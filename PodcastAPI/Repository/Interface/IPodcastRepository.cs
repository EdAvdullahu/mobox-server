using PodcastAPI.Models.Dto;

namespace PodcastAPI.Repository.Interface
{
    public interface IPodcastRepository
    {
        Task<IEnumerable<PodcastDto>> GetPodcasts();
        Task<PodcastDto> GetPodcastById(int Id);
        Task<PodcastDto> CreatePodcast(PodcastPutPost PodcastDto);
        Task<PodcastDto> UpdatePodcast(PodcastPutPost PodcastDto, int id);
        Task<bool> DeletePodcast(int Id);
    }
}
