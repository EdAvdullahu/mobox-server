using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface IReleaseService
    {
        Task<T> GetReleases<T>(string token);
        Task<T> GetReleaseById<T>(int ReleaseId,string token);
        Task<T> GetReleaseByArtist<T>(int ArtistsId,string token);
        Task<T> CreateUpdateRelease<T>(ReleasePutPost ReleaseDto,string token);
        Task<T> CreateUpdateRelease<T>(ReleasePutPost ReleaseDto, int id, string token);
        Task<T> DeleteRelease<T>(int ReleaseId,string token);
    }
}
