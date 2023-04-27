using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class ReleaseService: BaseService,IReleaseService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReleaseService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateUpdateRelease<T>(ReleasePutPost ReleaseDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = ReleaseDto,
                Url = SD.SongApiBase + "/api/Release",
                AccessToken = token
            });
        }

        public async Task<T> CreateUpdateRelease<T>(ReleasePutPost ReleaseDto, int id, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = ReleaseDto,
                Url = SD.SongApiBase + "/api/Release"+id,
                AccessToken = token
            });
        }

        public async Task<T> DeleteRelease<T>(int ReleaseId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.SongApiBase + "/api/Release"+ReleaseId,
                AccessToken = token
            });
        }

        public async Task<T> GetReleaseByArtist<T>(int ArtistsId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Release" + ArtistsId,
                AccessToken = token
            });
        }

        public async Task<T> GetReleaseById<T>(int ReleaseId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Release" + ReleaseId,
                AccessToken = token
            });
        }

        public async Task<T> GetReleases<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Release",
                AccessToken = token
            });
        }
    }
}
