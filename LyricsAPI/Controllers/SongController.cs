using LyricsAPI.Models.Dto;
using LyricsAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LyricsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        protected ResponseDto _response;
        private ISongRepository _songRepository;
        private ILyricRespository _lyricRepository;
        public SongController(ISongRepository songRepository, ILyricRespository lyricRepository)
        {
            _songRepository = songRepository;
            _response = new ResponseDto();
            _lyricRepository = lyricRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SongDto> songs = await _songRepository.GetSongs();
                _response.Result = songs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("lyrics")]
        public async Task<object> GetLyrics()
        {
            try
            {
                IEnumerable<LyricDto> lyrics = await _lyricRepository.GetLyrics();
                _response.Result = lyrics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}")]
        public async Task<object> Get(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid guidId))
                {
                    // Handle Guid ID
                    SongDto songs = await _songRepository.GetSongById(guidId);
                    _response.Result = songs;
                }
                else if (int.TryParse(id, out int intId))
                {
                    // Handle int ID
                    SongDto song = await _songRepository.GetSongByApiId(intId);
                    _response.Result = song;
                }
                else
                {
                    // Invalid ID format
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Invalid ID format." };
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("lyrics/{id}")]
        public async Task<object> GetLyricsById(Guid id)
        {
            try
            {
                LyricDto lyric = await _lyricRepository.GetLyricsById(id);
                _response.Result = lyric;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("lyrics/song/{id}")]
        public async Task<object> GetLyricsBySongId(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid guidId))
                {
                    // Handle Guid ID
                    LyricDto lyrics = await _lyricRepository.GetLyricsBySongId(guidId);
                    _response.Result = lyrics;
                }
                else if (int.TryParse(id, out int intId))
                {
                    // Handle int ID
                    LyricDto lyrics = await _lyricRepository.GetLyricsBySongApiId(intId);
                    _response.Result = lyrics;
                }
                else
                {
                    // Invalid ID format
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Invalid ID format." };
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post(SongPut songDto)
        {
            try
            {
                SongDto song = await _songRepository.CreateUpdateSong(songDto);
                _response.Result = song;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("lyrics")]
        public async Task<object> Post(LyricPut lyricDto)
        {
            try
            {
                LyricDto lyric = await _lyricRepository.CreateUpdateSong(lyricDto);
                _response.Result = lyric;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id}")]
        public async Task<object> Delete(Guid id)
        {
            try
            {
                bool deleted = await _songRepository.DeleteSong(id);
                _response.Result = deleted;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("lyrics/{id}")]
        public async Task<object> DeleteLyric(Guid id)
        {
            try
            {
                bool deleted = await _lyricRepository.DeleteLyric(id);
                _response.Result = deleted;
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
