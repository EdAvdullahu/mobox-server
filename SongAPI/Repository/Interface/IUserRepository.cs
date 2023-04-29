using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> CreateUpdateUser(UserPutPost user);
        Task<UserDto> CreateUpdateUser(UserPutPost user, int id);
        Task<bool> DeleteUser(int userId);
    }
}
