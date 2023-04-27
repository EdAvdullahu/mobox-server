using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/Song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        protected ResponseDto _response;
        private ISongRepository _songRepository;
        public SongController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
            _response = new ResponseDto();
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
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SongDto songs = await _songRepository.GetSongById(id);
                _response.Result = songs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> Post([FromBody] SongPutPost songDto)
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
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] SongPutPost songDto, int id)
        {
            try
            {
                SongDto song = await _songRepository.CreateUpdateSong(songDto, id);
                _response.Result = song;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        public async Task<object> Delete(int id)
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
    }
}
