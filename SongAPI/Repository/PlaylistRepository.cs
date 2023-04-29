using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PlaylistRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddCollaborator(CollaborationPutPost collab)
        {
            try
            {
                Collaboration coll = _mapper.Map<Collaboration>(collab);
                if (coll == null)
                {
                    return false;
                }
                _context.Collaborations.Add(coll);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddSong(SongPlaylistPutPost song)
        {
            try
            {
                Playlist playlist = await _context.Playlists.Where(x => x.PlaylitId == song.PlaylistId).FirstOrDefaultAsync();
                if (playlist == null)
                {
                    return false;
                }

                Song addSong = await _context.Songs.Where(x => x.SongId == song.SongId).FirstOrDefaultAsync();
                if (addSong == null)
                {
                    return false;
                }

                if (playlist.Songs == null)
                {
                    playlist.Songs = new List<Song>();
                }

                playlist.Songs.Add(addSong);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<PlaylistDto> CreateUpdateArtist(PlaylistPutPost aristDto, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaylistDto> CreateUpdatePlaylist(PlaylistPutPost playlistDto)
        {
            Playlist playlist = _mapper.Map<Playlist>(playlistDto);
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return _mapper.Map<Playlist, PlaylistDto>(playlist);
        }

        public async Task<bool> DeletePlaylist(Guid playlistId)
        {
            try
            {
                Playlist playlist = await _context.Playlists.Where(x => x.PlaylitId == playlistId).FirstOrDefaultAsync();
                if (playlist == null)
                {
                    return false;
                }
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PlaylistDto> GetPlaylistById(Guid playlitId)
        {
            Playlist playlist = await _context.Playlists.Include(x=>x.Songs).Where(x => x.PlaylitId == playlitId).FirstOrDefaultAsync();
            return _mapper.Map<PlaylistDto>(playlist);
        }

        public async Task<IEnumerable<PlaylistDto>> GetPlaylists()
        {
            IEnumerable<Playlist> playlistList = await _context.Playlists.ToListAsync();
            return _mapper.Map<List<PlaylistDto>>(playlistList);
        }

        public async Task<IEnumerable<PlaylistDto>> GetPlaylistsByUser(int userId)
        {
            IEnumerable<Playlist> playlistList = await _context.Playlists.Include(x=>x.Collaborations).Where(x=>x.OwnerId == userId || x.Collaborations.Any(p=> p.UserId==userId)).ToListAsync();
            return _mapper.Map<List<PlaylistDto>>(playlistList);
        }

        public async Task<bool> RemoveCollaborator(int collabId)
        {
            try
            {
                Collaboration collab = await _context.Collaborations.Where(x => x.Id == collabId).FirstOrDefaultAsync();
                if (collab == null)
                {
                    return false;
                }
                _context.Collaborations.Remove(collab);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveSong(SongPlaylistPutPost song)
        {
            try
            {
                Playlist playlist = await _context.Playlists.Where(x => x.PlaylitId == song.PlaylistId).FirstOrDefaultAsync();
                if (playlist == null)
                {
                    return false;
                }
                Song removeSong = await _context.Songs.Where(x => x.SongId == song.SongId).FirstOrDefaultAsync();
                if (removeSong == null)
                {
                    return false;
                }
                playlist.Songs.Remove(removeSong);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
