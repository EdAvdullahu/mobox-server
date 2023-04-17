using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IReleaseRepository
    {
        Task<IEnumerable<ReleaseDto>> GetReleases();
        Task<ReleaseDto> GetReleaseById(int ReleaseId);
        Task<IEnumerable<ReleaseDto>> GetReleaseByArtist(int ArtistsId);
        Task<ReleaseDto> CreateUpdateRelease(ReleasePutPost ReleaseDto);
        Task<ReleaseDto> CreateUpdateRelease(ReleasePutPost ReleaseDto, int id);
        Task<bool> DeleteRelease(int ReleaseId);
    }
}
