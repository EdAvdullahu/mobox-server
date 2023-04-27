using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface IFeatureService
    {
        Task<T> GetFeatures<T>(string token);
        Task<T> GetFeaturesBySongId<T>(int SongId, string token);
        Task<T> AddFeature<T>(FeaturePutPost FeatureDto,string token);
        Task<T> DeleteFeature<T>(int FeatureId,string token);
    }
}
