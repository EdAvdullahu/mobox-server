using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Services.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        protected ResponseDto _response;
        private IRecommendationService _recommendationService;
        public RecommendationController(IRecommendationService recommendationService)
        {
            _response = new ResponseDto();
            _recommendationService = recommendationService;
        }
        [HttpGet("{playlistId}")]
        public async Task<object> Get(Guid playlistId)
        {
            try
            {
                var songs = await _recommendationService.GetRecommendations(playlistId);
                _response.Result = songs;
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
