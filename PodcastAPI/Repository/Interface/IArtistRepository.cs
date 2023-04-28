using PodcastAPI.Models.Dto;

namespace PodcastAPI.Repository.Interface
{
    public interface IArtistRepository
    {
        Task<IEnumerable<ArtistDto>> GetArtists();
        Task<ArtistDto> GetArtistById(int Id);
        Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto);
        Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto, int id);
        Task<bool> DeleteArtist(int Id);
    }
}
