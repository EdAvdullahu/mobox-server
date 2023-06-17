using AutoMapper;
using MailKit.Search;
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
        private readonly ISongStatistics _songStatistics;
        private readonly IUserStatistics _userStatistics;

        public UserRepository(ApplicationDbContext context, IMapper mapper, ISongStatistics songStatistics, IUserStatistics userStatistics)
        {
            _context = context;
            _mapper = mapper;
            _songStatistics = songStatistics;
            _userStatistics = userStatistics;
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

        public async Task<UserExplore> GetUserExplore(int id)
        {
            UserExplore userExplore = new UserExplore();
            User user = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            DateTime currentMonthStartDate = DateTime.Now.AddDays(-DateTime.Now.Day + 1).Date;
            DateTime currentMonthEndDate = DateTime.Now.Date;
            var playSongs = await _context.Streams
            .Where(ps => ps.UserId == id && ps.ListenDateTime >= currentMonthStartDate && ps.ListenDateTime <= currentMonthEndDate)
            .ToListAsync();

            var mostListenedSongs = playSongs
                .GroupBy(ps => ps.SongId)
                .OrderByDescending(g => g.Count())
                .Take(20)
                .Select(g => g.First().Song) // Get the first Song from each group
                .ToList();
            userExplore.UserId = user.UserId;
            userExplore.UserName = user.UserName;
            IEnumerable<Song> songs = await _context.Songs
    .Where(x => mostListenedSongs.Select(s => s.SongId).Contains(x.SongId))
    .ToListAsync();

            songs = songs.Where(song => song != null).ToList(); // Null check
            SongDto s = await _songStatistics.GetTodaysTrendingSong();
            IEnumerable<ArtistDto> artistDtos = await _userStatistics.GetTrendingArtists();
            userExplore.TrendingSong = _mapper.Map<Song>(s);
            userExplore.TrendingArtist = artistDtos;
            userExplore.MostPlayed = songs;
            return userExplore;
        }

        public async Task<IEnumerable<User>> SearchUsers(string[] name)
        {
            var lowerSearchTerms = name.Select(term => term.ToLower()).ToArray();
            IEnumerable<User> res = await _context.Users.ToListAsync();
                return res.Where(user => lowerSearchTerms.Any(term => (user.UserName.ToLower()).Contains(term)));
        }

        public async Task<PublicProfile> GetUserPublicProfile(Guid userId)
        {
            User user = await _context.Users.Where(x => x.UISId == userId).FirstOrDefaultAsync();
            IEnumerable<Playlist> publicPlaylist = await _context.Playlists.Where(x => x.OwnerId == user.UserId && x.IsPublic == true).ToListAsync();
            PublicProfile profile = new PublicProfile()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PublicPlaylists = _mapper.Map<List<PlaylistDto>>(publicPlaylist)
            };
            return profile;
        }
    }
}
