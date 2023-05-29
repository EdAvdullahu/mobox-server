using EmailAPI.Models;
using EmailAPI.Repository;
using EmailAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Email : ControllerBase
    {
        private readonly IEmailService _email;
        private readonly IEmailRepository _repo;
        private readonly ResponseDto _response;
        public Email(IEmailService email, IEmailRepository repo){
            _email = email;
            _repo = repo;
            _response = new ResponseDto();
        }
        [HttpPost("send")]
        public async Task<object> SendEmail(EmailLog email)
        {
            try
            {
                _response.IsSuccess = await _email.SendEmail(email); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        public async Task<object> GetEmails()
        {
            try
            {
                _response.Result = await _repo.GetAsync();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> AddEmail(EmailLog email)
        {
            try
            {
                await _repo.CreateAsync(email);
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
