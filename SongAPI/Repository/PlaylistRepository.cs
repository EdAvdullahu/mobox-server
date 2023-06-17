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

        public async Task<SongPlaylistDto> AddSong(SongPlaylistPutPost song)
        {
                PlaylistSong pls = _mapper.Map<PlaylistSong>(song);
                _context.PlaylistsSong.Add(pls);
                await _context.SaveChangesAsync();
                return _mapper.Map<SongPlaylistDto>(pls);
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

        public async Task<bool> DeletePlaylist(Guid playlistId, int userId)
        {
            try
            {
                Playlist playlist = await _context.Playlists.Where(x => x.PlaylitId == playlistId).FirstOrDefaultAsync();
                if (playlist == null)
                {
                    return false;
                }
                if(playlist.OwnerId != userId)
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

        public async Task<object> GetPlaylistById(Guid playlitId)
        {
            var playlist = await _context.Playlists.Include(x=>x.Songs).ThenInclude(x=>x.Song).ThenInclude(x=>x.Features).ThenInclude(x=>x.Artist)
                .Include(x=>x.Songs).ThenInclude(x=>x.Song).ThenInclude(x=>x.Genres).ThenInclude(x=>x.Genre)
                .Include(x=>x.Songs).ThenInclude(x=>x.Song).ThenInclude(x=>x.Release)
                .Include(x=>x.PlaylistLikes)
                .Where(x => x.PlaylitId == playlitId)
                .Select(x=> new
                {
                    PlaylistId = x.PlaylitId,
                    IsPublic = x.IsPublic,
                    Title = x.Tittle,
                    OwnerId = x.OwnerId,
                    Description = x.Description,
                    LikeCount = x.PlaylistLikes.Count,
                    Songs = x.Songs.Select(r => new
                    {
                        SongId = r.SongId,
                        SongPlaylistId = r.PlaySongId,
                        Name = r.Song.Name,
                        ReleaseDate = r.Song.ReleaseDate,
                        Length = r.Song.Length,
                        Path = r.Song.Path,
                        ImageUrl = r.Song.ImageUrl,
                        IsExplicit = r.Song.IsExplicite,
                        HasFeatures = r.Song.HasFeatures,
                        ReleaseId = r.Song.ReleaseId,
                        Release = new
                        {
                            ReleaseId = r.Song.ReleaseId,
                            Title = r.Song.Release.Title,
                        },
                        Features = r.Song.Features.Select(f => new
                        {
                            ArtistId = f.Artist.ArtistId,
                            Name = f.Artist.Name
                        }).ToList(),
                        Genres = r.Song.Genres.Select(g => new
                        {
                            GenreId = g.Genre.GenreId,
                            Name = g.Genre.Name,
                            Description = g.Genre.Description
                        }).ToList()
                    })
                })
                .FirstOrDefaultAsync();
            return playlist;
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

        public async Task<bool> RemoveSong(int plsId)
        {
            try
            {
                PlaylistSong pls = await _context.PlaylistsSong.Where(x => x.PlaySongId == plsId).FirstOrDefaultAsync();
                if (pls == null)
                {
                    return false;
                }
                _context.PlaylistsSong.Remove(pls);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AddPlaylistToLiked(PlaylistLikePutPost plLike)
        {
            try{
                plLike.LikeDateTime = DateTime.Now;
                PlaylistLike plL = _mapper.Map<PlaylistLike>(plLike);
                _context.PlaylistsLike.Add(plL);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<CollaborationDto>> GetCollabs(Guid playlistId)
        {
            IEnumerable<Collaboration> collaborations = _context.Collaborations.Include(x=> x.User).Where(x => x.PlaylistId == playlistId);
            return Task.FromResult(_mapper.Map<IEnumerable<CollaborationDto>>(collaborations));
        }

        public async Task<HasReadWritePerm> UserPermissionsForPlaylist(int userIt, Guid playlistId)
        {
            HasReadWritePerm hasReadWritePerm = new HasReadWritePerm();
            Playlist playlist = await _context.Playlists.Include(x => x.Collaborations).FirstOrDefaultAsync(x => x.PlaylitId == playlistId);
            hasReadWritePerm.CanDelete = false;
            hasReadWritePerm.CanAdd = false;
            if (playlist == null)
            {
                
            }
            else
            {
                hasReadWritePerm.UserId = userIt;
                hasReadWritePerm.PlaylistId = playlistId;
                if(playlist.OwnerId==userIt)
                {
                    hasReadWritePerm.CanDelete = true;
                    hasReadWritePerm.CanAdd= true;
                }
                else
                {
                    playlist.Collaborations.ToList().ForEach(playlist =>
                    {
                        if (playlist.UserId == userIt)
                        {
                            hasReadWritePerm.CanDelete = playlist.CanRemoveSongs;
                            hasReadWritePerm.CanAdd = playlist.CanAddSongs;
                        }
                    });
                }
            }
            return hasReadWritePerm;
        }
    }
}
