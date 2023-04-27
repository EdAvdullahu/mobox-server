using Web.Models;
using Web.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class SongGenreService: BaseService,ISongGenreService
    {
        private readonly IHttpClientFactory _clientFactory;
        public SongGenreService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> AddGenre<T>(SongGenrePutPost GenreDto, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = GenreDto,
                Url = SD.SongApiBase + "/api/SongGenre",
                AccessToken = token
            });
        }

        public async Task<T> DeleteFeature<T>(int GenreId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.SongApiBase + "/api/SongGenre"+ GenreId,
                AccessToken = token
            });
        }

        public async Task<T> GetSongGenresForSong<T>(int SongId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/SongGenre" + SongId,
                AccessToken = token
            });
        }

        public async Task<T> GetSongsWithGenre<T>(int GenreId, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SongApiBase + "/api/SongGenre" + GenreId,
                AccessToken = token
            });
        }
    }
}
