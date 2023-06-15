using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using System.Collections.Generic;

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

        public async  Task<WhoAmI> WhoAmI(string name)
        {
            User user = await _context.Users.Where(x => x.UserName.Equals(name)).FirstOrDefaultAsync();
            WhoAmI whoAmI = new WhoAmI()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Playlists = await GetPlaylistsByUser(user.UserId),
                PlaylistLikes = await GetPlaylistLikesByUser(user.UserId),
                SongLikes = await GetSongLikesByUser(user.UserId)
            };
            return whoAmI;
        }

        private async Task<List<SongLike>> GetSongLikesByUser(int userId)
        {
            IEnumerable<SongLike> songlist = await _context.SongsLike.Include(x=>x.Song).ThenInclude(c=>c.Features).ThenInclude(a=>a.Artist)
                .Include(x=>x.Song).ThenInclude(c=>c.Release)
                .Include(x=>x.Song).ThenInclude(c=>c.Genres).ThenInclude(a=>a.Genre)
                .Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<List<SongLike>>(songlist);
        }

        private async Task<List<PlaylistLike>> GetPlaylistLikesByUser(int userId)
        {
            IEnumerable<PlaylistLike> playlistList = await _context.PlaylistsLike.Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<List<PlaylistLike>>(playlistList);
        }

        private async Task<List<PlaylistDto>> GetPlaylistsByUser(int userId)
        {
            IEnumerable<Playlist> playlistList = await _context.Playlists.Include(x => x.Collaborations).Include(x=>x.PlaylistLikes).Where(x => x.OwnerId == userId || x.Collaborations.Any(p => p.UserId == userId)).ToListAsync();
            List<PlaylistDto> pdo =  _mapper.Map<List<PlaylistDto>>(playlistList);
            for(var i=0; i < pdo.Count(); i++)
            {
                pdo.ElementAt(i).LikesCount = playlistList.ElementAt(i).PlaylistLikes.Count();
            }
            return pdo;
        }

        public async Task<List<SongLike>> LikedSongs(int id)
        {
            return await GetSongLikesByUser(id);
        }

        public async Task<UserDto> GetUserByUISId(Guid uisid)
        {
            User user = await _context.Users.Where(x => x.UISId == uisid).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
