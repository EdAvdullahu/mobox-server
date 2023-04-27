using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class GenreService :BaseService,IGenreService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GenreService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateUpdateGenre<T>(GenrePutPost GenreDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = GenreDto,
                Url = SD.SongApiBase + "/api/Genre",
                AccessToken = token
            });
        }

        public async Task<T> CreateUpdateGenre<T>(GenrePutPost GenreDto, int id, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = GenreDto,
                Url = SD.SongApiBase + "/api/Genre"+id,
                AccessToken = token
            });
        }

        public async Task<T> DeleteGenre<T>(int GenreId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.SongApiBase + "/api/Genre" + GenreId,
                AccessToken = token
            });
        }

        public async Task<T> GetGenreByID<T>(int GenreId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Genre/" + GenreId,
                AccessToken = token
            });
        }

        public async Task<T> GetGenres<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/Genre/",
                AccessToken = token
            });
        }
    }
}
