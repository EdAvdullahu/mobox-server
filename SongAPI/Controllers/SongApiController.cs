using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository;
using SongAPI.Repository.Interface;
using SongAPI.Services;
using SongAPI.Services.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongApiController : ControllerBase
    {
        protected ResponseDto _response;
        private ISongService _songService;
        public SongApiController(ISongService songService)
        {
            _response = new ResponseDto();
            _songService = songService;
        }
        [HttpPost]
        public async Task<object> Post(ReleasePostRequest Release)
        {
            try
            {
                ReleaseGetRequest release = await _songService.CreateRelease(Release);
                _response.Result = release;
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
