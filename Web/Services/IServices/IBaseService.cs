using AutoMapper.Internal;
using Web.Models;

namespace Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
