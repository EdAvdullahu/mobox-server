using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<FeatureDto>> GetFeatures();
        Task<IEnumerable<FeatureDto>> GetFeaturesBySongId(int SongId);
        Task<FeatureDto> AddFeature(FeaturePutPost FeatureDto);
        Task<bool> DeleteFeature(int FeatureId);
    }
}
