using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongGenreController : ControllerBase
    {
        protected ResponseDto _response;
        private ISongGenreRepository _repository;
        public SongGenreController(ISongGenreRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet("genre/{id}")]
        public async Task<object> GetSongs(int id)
        {
            try
            {
                IEnumerable<SongGenreDto> songs = await _repository.GetSongsWithGenre(id);
                _response.Result = songs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("song/{id}")]
        public async Task<object> GetGenres(int id)
        {
            try
            {
                IEnumerable<SongGenreDto> features = await _repository.GetSongGenresForSong(id);
                _response.Result = features;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> Post([FromBody] SongGenrePutPost SongGenreDto)
        {
            try
            {
                SongGenreDto songGenre = await _repository.AddGenre(SongGenreDto);
                _response.Result = songGenre;
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
                bool deleted = await _repository.DeleteFeature(id);
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
