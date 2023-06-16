using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/Feature")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        protected ResponseDto _response;
        private IFeatureRepository _featureRepository;
        public FeatureController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Authorize]
        
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<FeatureDto> songs = await _featureRepository.GetFeatures();
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
        [Authorize]
        
        public async Task<object> Get(int id)
        {
            try
            {
                IEnumerable<FeatureDto> features = await _featureRepository.GetFeaturesBySongId(id);
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
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> Post([FromBody] FeaturePutPost featureDto)
        {
            try
            {
                FeatureDto feature= await _featureRepository.AddFeature(featureDto);
                _response.Result = feature;
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
                bool deleted = await _featureRepository.DeleteFeature(id);
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
