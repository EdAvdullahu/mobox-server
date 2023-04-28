using Microsoft.AspNetCore.Mvc;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;

namespace PodcastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodcastController : ControllerBase
    {
        protected ResponseDto _response;
        private IPodcastRepository _podcastRepository;
        public PodcastController( IPodcastRepository podcastRepository) 
        { 
            _response= new ResponseDto();
            _podcastRepository= podcastRepository;
            
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PodcastDto> podcasts = await _podcastRepository.GetPodcasts();
                _response.Result = podcasts;
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
                PodcastDto podcast = await _podcastRepository.GetPodcastById(id);
                _response.Result = podcast;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> Post([FromForm] PodcastPutPost podcastDto)
        {
            try
            {
                PodcastDto podcast = await _podcastRepository.CreatePodcast(podcastDto);
                _response.Result = podcast;
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
                bool deleted = await _podcastRepository.DeletePodcast(id);
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
