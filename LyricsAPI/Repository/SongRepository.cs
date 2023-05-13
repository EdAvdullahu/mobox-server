using AutoMapper;
using LyricsAPI.DbContexts;
using LyricsAPI.Models;
using LyricsAPI.Models.Dto;
using LyricsAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LyricsAPI.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public SongRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SongDto> CreateUpdateSong(SongPut songPut)
        {
            Song song = _mapper.Map<SongPut, Song>(songPut);
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return _mapper.Map<Song, SongDto>(song);
        }

        public async Task<bool> DeleteSong(Guid songId)
        {
            try
            {
                Song song = await _context.Songs.Where(x => x.SongId == songId).FirstOrDefaultAsync();
                if (song == null)
                {
                    return false;
                }
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SongDto> GetSongByApiId(int Songid)
        {
            Song song = await _context.Songs.FirstOrDefaultAsync(x => x.SongApiId == Songid);
            SongDto songDto = _mapper.Map<SongDto>(song);
            return songDto;
        }

        public async Task<SongDto> GetSongById(Guid Songid)
        {
            Song song = await _context.Songs.FirstOrDefaultAsync(x => x.SongId == Songid);
            SongDto songDto = _mapper.Map<SongDto>(song);
            return songDto;
        }

        public async Task<IEnumerable<SongDto>> GetSongs()
        {
            IEnumerable<Song> songList = await _context.Songs.ToListAsync();
            return _mapper.Map<List<SongDto>>(songList);
        }
    }
}
