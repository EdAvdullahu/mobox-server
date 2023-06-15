using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class StreamRepository : IStreamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StreamRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlaySongDto>> getSongStreams(int songId)
        {
            IEnumerable<PlaySong> streams = await _context.Streams.Where(s => s.SongId == songId).ToListAsync();
            return _mapper.Map<IEnumerable<PlaySongDto>>(streams);
        }

        public async Task<IEnumerable<PlaySongDto>> getUserStreams(int userId)
        {
            IEnumerable<PlaySong> streams = await _context.Streams.Where(s => s.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<PlaySongDto>>(streams);
        }

        public async Task<bool> StreamSong(PlaySongCreateDto stream)
        {
            try
            {
                PlaySong song = _mapper.Map<PlaySong>(stream);
                song.ListenDateTime = DateTime.Now;
                _context.Streams.Add(song);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
