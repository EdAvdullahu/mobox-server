using AutoMapper.Internal;
using Web.Models;
using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
