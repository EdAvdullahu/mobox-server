using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.DbContexts;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodcastAPI.Repository
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

        public async Task<UserDto> CreateUpdateUser(UserPutPost user, int id)
        {
            User existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                throw new Exception("User not found.");

            existingUser.UserName = user.UserName;
            await _context.SaveChangesAsync();

            return _mapper.Map<User, UserDto>(existingUser);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            User user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            User user = await _context.Users.FindAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            IEnumerable<User> userList = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<WhoAmI> WhoAmI(string name)
        {
            User user = await _context.Users.SingleOrDefaultAsync(x => x.UserName.Equals(name));
            if (user == null)
                throw new Exception("User not found.");

            WhoAmI whoAmI = new WhoAmI()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Playlists = await GetPlaylistsByUser(user.Id),
                PlaylistLikes = await GetPlaylistLikesByUser(user.Id),
                PodcastLikes = await GetPodcastLikesByUser(user.Id)
            };
            return whoAmI;
        }

        private async Task<List<PodcastLike>> GetPodcastLikesByUser(int userId)
        {
            IEnumerable<PodcastLike> podcastlist = await _context.PodcastLikes
                .Include(x => x.Podcast)
                .ThenInclude(c => c.Genres).ThenInclude(a => a.Genre)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<PodcastLike>>(podcastlist);
        }

        private async Task<List<PlaylistDto>> GetPlaylistsByUser(int userId)
        {
            IEnumerable<Playlist> playlistList = await _context.Playlists
                .Include(x => x.PlaylistLikes)
                .Where(x => x.OwnerId == userId)
                .ToListAsync();

            List<PlaylistDto> pdo = _mapper.Map<List<PlaylistDto>>(playlistList);
            for (var i = 0; i < pdo.Count(); i++)
            {
                pdo.ElementAt(i).LikesCount = playlistList.ElementAt(i).PlaylistLikes.Count();
            }
            return pdo;
        }
        private async Task<List<PlaylistLike>> GetPlaylistLikesByUser(int userId)
        {
            IEnumerable<PlaylistLike> playlistList = await _context.PlaylistsLike.Where(x => x.Id == userId).ToListAsync();
            return _mapper.Map<List<PlaylistLike>>(playlistList);
        }


        public async Task<List<PodcastLike>> LikedPodcasts(int id)
        {
            return await GetPodcastLikesByUser(id);
        }

        public async Task<List<PodcastLike>> LikedPodcastsByUser(int userId)
        {
            return await GetPodcastLikesByUser(userId);
        }


    
    }
}
