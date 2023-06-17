using SongAPI.Models;
using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> GetUserByUISId(Guid uisid);
        Task<UserDto> CreateUpdateUser(UserPutPost user);
        Task<UserDto> CreateUpdateUser(UserPutPost user, int id);
        Task<bool> DeleteUser(int userId);
        Task<WhoAmI> WhoAmI(string name);
        Task<List<SongLike>> LikedSongs(int id);
        Task<UserExplore> GetUserExplore(int id);
        Task<IEnumerable<User>> SearchUsers(string[] name);
        Task<PublicProfile> GetUserPublicProfile(Guid userId);
    }
}
