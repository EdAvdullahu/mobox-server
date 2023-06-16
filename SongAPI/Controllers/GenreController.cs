using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/Genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        protected ResponseDto _response;
        private IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<GenreDto> genres = await _genreRepository.GetGenres();
                _response.Result = genres;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<object> Get(int id)
        {
            try
            {
                GenreDto genre = await _genreRepository.GetGenreByID(id);
                _response.Result = genre;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<object> Post([FromBody] GenrePutPost genreDto)
        {
            try
            {
                GenreDto genre = await _genreRepository.CreateUpdateGenre(genreDto);
                _response.Result = genre;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Put([FromBody] GenrePutPost genreDto, int id)
        {
            try
            {
                GenreDto genre = await _genreRepository.CreateUpdateGenre(genreDto, id);
                _response.Result = genre;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool deleted = await _genreRepository.DeleteGenre(id);
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
