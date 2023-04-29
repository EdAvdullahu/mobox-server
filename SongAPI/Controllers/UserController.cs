using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
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
        [HttpPost]
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
