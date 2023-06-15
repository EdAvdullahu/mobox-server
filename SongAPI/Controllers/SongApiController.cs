using AutoMapper.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository;
using SongAPI.Repository.Interface;
using SongAPI.Services;
using SongAPI.Services.Interface;

namespace SongAPI.Controllers
{
    [Route("api/SongAPI")]
    [ApiController]
    public class SongApiController : ControllerBase
    {
        protected ResponseDto _response;
        private ISongService _songService;
        private IArtistRepository _artistRepository;
        private ISearchRepository _searchRepository;
        private IReleaseRepository _releaseRepository;
        private IStreamRepository _streamRepository;
        public SongApiController(ISongService songService, IArtistRepository artistRepository, ISearchRepository searchRepository, IReleaseRepository releaseRepository, IStreamRepository streamRepository)
        {
            _response = new ResponseDto();
            _songService = songService;
            _artistRepository = artistRepository;
            _searchRepository = searchRepository;
            _releaseRepository = releaseRepository;
            _streamRepository = streamRepository;
        }
        [HttpGet("artist/{id}")]
        public async Task<object> FilterByArtist(int id)
        {
            try
            {
                object release = await _artistRepository.GetArtist(id);
                _response.Result = release;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("genre/filter")]
        public async Task<object> Get(string genres)
        {
            try
            {
                var songs = await _searchRepository.FilterByGere(genres);
                _response.Result = songs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("search/{name}")]
        public async Task<object> Search(string name)
        {
            try
            {
                string[] terms = name.Split(' ');
                object release = _searchRepository.SearchByName(terms);
                _response.Result = release;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("release/{id}")]
        public async Task<object> GetReleaseById(int id)
        {
            try
            {
                object release = await _releaseRepository.GetReleaseById(id);
                _response.Result = release;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("stream/song/{id}")]
        public async Task<object> GetStreamsForSong(int songId)
        {
            try
            {
                IEnumerable<PlaySongDto> streams = await _streamRepository.getSongStreams(songId);
                _response.Result = streams;
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("stream/user/{id}")]
        public async Task<object> GetStreamsForUser(int userId)
        {
            try
            {
                IEnumerable<PlaySongDto> streams = await _streamRepository.getUserStreams(userId);
                _response.Result = streams;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("release")]
        public async Task<object> Post([FromForm]ReleasePostRequest Release)
        {
            try
            {
                ReleaseDto release = await _songService.CreateRelease(Release);
                _response.Result = release;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("song")]
        public async Task<object> PostSong([FromForm] SongPostRequest song, [FromForm] string features, [FromForm] string genres)
        {
            try
            {
                // Deserialize the features and genres JSON data
                song.Features = JsonConvert.DeserializeObject<List<FeaturePutPost>>(features);
                song.Genres = JsonConvert.DeserializeObject<List<SongGenrePutPost>>(genres);

                SongGetRequest Song = await _songService.CreateSong(song);
                _response.Result = Song;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("stream")]
        public async Task<object> StreamSong(PlaySongCreateDto stream)
        {
            try
            {
                bool result = await _streamRepository.StreamSong(stream);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
