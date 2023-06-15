using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/Artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        protected ResponseDto _response;
        private IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Authorize]
        
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ArtistDto> artists = await _artistRepository.GetArtists();
                _response.Result = artists;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}")]
        [Authorize(Roles ="Listener, Artist, Admin")]
        public async Task<object> Get(int id)
        {
            try
            {
                ArtistDto artist = await _artistRepository.GetArtistById(id);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("name/{name}")]
        public async Task<object> GetByNae(string name)
        {
            try
            {
                IEnumerable<ArtistDto> artists = await _artistRepository.GetArtistsByName(name);
                _response.Result = artists;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }   
        [HttpPost]
        [Authorize]
        public async Task<object> Post(ArtistPutPost artistDto)
        {
            try
            {
                ArtistDto artist = await _artistRepository.CreateUpdateArtist(artistDto);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<object> Put([FromBody] ArtistPutPost artistDto, int id)
        {
            try
            {
                ArtistDto artist = await _artistRepository.CreateUpdateArtist(artistDto, id);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        [Authorize]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool deleted = await _artistRepository.DeleteArtist(id);
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
