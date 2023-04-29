using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUpdateUser(UserPutPost user)
        {
            User newUser = _mapper.Map<UserPutPost, User>(user);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDto>(newUser);
        }

        public Task<UserDto> CreateUpdateUser(UserPutPost user, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                User user = await _context.Users.Where(x => x.UserId== userId).FirstOrDefaultAsync();
                if (user == null)
                {
                    return false;
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            User user = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            IEnumerable<User> userList = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }
    }
}
