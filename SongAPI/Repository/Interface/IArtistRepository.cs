using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IArtistRepository
    {
        Task<IEnumerable<ArtistDto>> GetArtists();
        Task<ArtistDto> GetArtistById(int artistId);
        Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto);
        Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto, int id);
        Task<bool> DeleteArtist(int artistId);
    }
}
