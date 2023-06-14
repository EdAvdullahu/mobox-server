using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.DbContexts;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;
using System;

namespace PodcastAPI.Repository
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

        public async Task<PodcastPlaylistDto> AddPodcastToPlaylist(PodcastPlaylistPutPost podcast)
        {
            
            PlaylistPodcast pls = _mapper.Map<PlaylistPodcast>(podcast);
            _context.PlaylistPodcasts.Add(pls);
            await _context.SaveChangesAsync();
            return _mapper.Map<PodcastPlaylistDto>(pls);
               // return true;// Cannot implicitly convert type 'bool' to 'PodcastAPI.Models.Dto.PodcastPlaylistDto' 
            
          
        }


        public async Task<PlaylistDto> CreateUpdatePlaylist(PlaylistPutPost playlistDto)
        {
            Playlist playlist = _mapper.Map<Playlist>(playlistDto);
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlaylistDto>(playlist);
        }

        public async Task<bool> DeletePlaylist(Guid playlistId)
        {
            try
            {
                Playlist playlist = await _context.Playlists.Where(x => x.Id == playlistId).FirstOrDefaultAsync();
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

        public async Task<object> GetPlaylistById(Guid playlistId)
        {
            var playlist = await _context.Playlists
                .Include(x => x.Podcasts)
                .ThenInclude(x => x.Podcast)
                .Where(x => x.Id == playlistId)
                .Select(x => new
                {
                    PlaylistId = x.Id,
                    IsPublic = x.IsPublic,
                    Title = x.Tittle,
                    OwnerId = x.OwnerId,
                    Description = x.Description,
                    LikeCount = x.PlaylistLikes.Count,
                    Podcasts = x.Podcasts.Select(p => new
                    {
                        PodcastId = p.Id,
                        Title = p.Podcast.Title,
                        Length = p.Podcast.Length,
                        Genres = p.Podcast.Genres.Select(g => new
                        {
                            GenreId = g.Genre.Id,
                            Name = g.Genre.Name,
                            Description = g.Genre.Description
                        })
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
            IEnumerable<Playlist> playlistList = await _context.Playlists
                .Where(x => x.OwnerId == userId)
                .ToListAsync();

            return _mapper.Map<List<PlaylistDto>>(playlistList);
        }

        public async Task<bool> RemovePodcastFromPlaylist(int playlistPodcastId)
        {
            try
            {
                PlaylistPodcast pls = await _context.PlaylistPodcasts
                    .Where(x => x.Id == playlistPodcastId)
                    .FirstOrDefaultAsync();

                if (pls == null)
                {
                    return false;
                }

                _context.PlaylistPodcasts.Remove(pls);
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
            try
            {
                plLike.LikeDateTime = DateTime.Now;
                PlaylistLike plL = _mapper.Map<PlaylistLike>(plLike);
                _context.PlaylistsLike.Add(plL);
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