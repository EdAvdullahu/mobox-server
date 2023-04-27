using AutoMapper.Internal;
using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class ArtistService : BaseService,IArtistService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArtistService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateUpdateArtist<T>(ArtistPutPost aristDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = aristDto,
                Url = SD.SongApiBase + "/api/Artist",
                AccessToken = token
            });
        }

        public async Task<T> CreateUpdateArtist<T>(ArtistPutPost artistDto, int id, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = artistDto,
                Url = SD.SongApiBase + "/api/Artist"+id,
                AccessToken = token
            });
        }

        public async Task<T> DeleteArtist<T>(int artistId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.SongApiBase + "/api/Artist" + artistId,
                AccessToken = token
            });
        }

        public async Task<T> GetArtist<T>(int artistId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Artist/" + artistId,
                AccessToken = token
            });
        }

        public async Task<T> GetArtistById<T>(int artistId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Artist/" + artistId,
                AccessToken = token
            });
        }

        public async Task<T> GetArtists<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Artist",
                AccessToken = token
            });
        }
    }
}
