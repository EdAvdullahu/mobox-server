using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
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
        public async Task<SongDto> CreateUpdateSong(SongPutPost songDto)
        {
            Song song = _mapper.Map<SongPutPost, Song>(songDto);
            song.ReleaseDate = DateTime.Now;
            song.Length = TimeSpan.FromSeconds(songDto.LengthInSec);
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return _mapper.Map<Song, SongDto>(song);
        }
        public async Task<SongDto> CreateUpdateSong(SongPutPost songDto, int id)
        {
            Song song = await _context.Songs.Where(x=>x.SongId==id).FirstOrDefaultAsync();
            song = _mapper.Map<SongPutPost, Song>(songDto);
            song.Length = TimeSpan.FromSeconds(songDto.LengthInSec);
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
            return _mapper.Map<Song, SongDto>(song);
        }

        public async Task<bool> DeleteSong(int SongId)
        {
            try
            {
                Song song = await _context.Songs.Where(x => x.SongId == SongId).FirstOrDefaultAsync();
                if(song == null)
                {
                    return false;
                }
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<SongDto> GetSongById(int SongId)
        {
            Song song = await _context.Songs.Where(x=>x.SongId==SongId).FirstOrDefaultAsync();
            return _mapper.Map<SongDto>(song);
        }

        public async Task<IEnumerable<SongDto>> GetSongs()
        {
            IEnumerable<Song> songList = await _context.Songs.ToListAsync();
            return _mapper.Map<List<SongDto>>(songList);
        }
    }
}
