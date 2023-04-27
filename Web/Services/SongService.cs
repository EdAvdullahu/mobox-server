using Newtonsoft.Json.Linq;
using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class SongService: BaseService,ISongService
    {
        private readonly IHttpClientFactory _clientFactory;
        public SongService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateUpdateSong<T>(SongPutPost songDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = songDto,
                Url = SD.SongApiBase + "/api/SongGenre",
                AccessToken = token
            });
        }

        public async Task<T> CreateUpdateSong<T>(SongPutPost songDto, int id,string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = songDto,
                Url = SD.SongApiBase + "/api/SongGenre"+id,
                AccessToken = token
            });
        }

        public async Task<T> DeleteSong<T>(int SongId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.SongApiBase + "/api/SongGenre" + SongId,
                AccessToken = token
            });
        }

        public async Task<T> GetSongById<T>(int SongId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/SongGenre" + SongId,
                AccessToken = token
            });
        }

        public async Task<T> GetSongs<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/SongGenre",
                AccessToken = token
            });
        }
    }
}
