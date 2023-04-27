using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{

    public class FeatureService : BaseService, IFeatureService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FeatureService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> AddFeature<T>(FeaturePutPost FeatureDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = FeatureDto,
                Url = SD.SongApiBase + "/api/Feature",
                AccessToken = token
            });
        }

        public async Task<T> DeleteFeature<T>(int FeatureId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.SongApiBase + "/api/Feature" + FeatureId,
                AccessToken = token
            });
        }

        public async Task<T> GetFeatures<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Feature",
                AccessToken = token
            });
        }

        public async Task<T> GetFeaturesBySongId<T>(int SongId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Feature"+SongId,
                AccessToken = token
            });
        }
    }
}
