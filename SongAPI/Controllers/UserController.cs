using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<object> Get()
        {
            try
            {
                IEnumerable<UserDto> users = await _userRepository.GetUsers();
                _response.Result = users;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("likes/{id}")]
        [Authorize]
        public async Task<object> GetLikedSongs(int id)
        {
            try
            {
                List<SongLike> songs = await _userRepository.LikedSongs(id);
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
                UserDto user = await _userRepository.GetUserById(id);
                _response.Result = user;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("whoami/{name}")]
        [Authorize]
        public async Task<object> WhoAmI(string name)
        {
            try
            {
                WhoAmI who = await _userRepository.WhoAmI(name);
                _response.Result = who;
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
        public async Task<object> Post( UserPutPost userDto)
        {
            try
            {
                UserDto user = await _userRepository.CreateUpdateUser(userDto);
                _response.Result = user;
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
                bool deleted = await _userRepository.DeleteUser(id);
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
