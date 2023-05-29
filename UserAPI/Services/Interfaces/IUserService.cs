using UserAPI.Models.Dto;
using UserAPI.Models;
using System.Security.Cryptography;

namespace UserAPI.Services.Interfaces
{
    public interface IUserService
    {
        RefreshToken GenerateRefreshToken();
        string CreateToken(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateRandomToken();
    }
}
