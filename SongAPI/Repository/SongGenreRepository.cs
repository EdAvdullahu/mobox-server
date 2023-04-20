using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Migrations;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using SongGenre = SongAPI.Models.SongGenre;

namespace SongAPI.Repository
{
    public class SongGenreRepository : ISongGenreRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public SongGenreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SongGenreDto> AddGenre(SongGenrePutPost GenreDto)
        {
            GenreSong songGenre = _mapper.Map<SongGenrePutPost, GenreSong>(GenreDto);
            _context.GenreSong.Add(songGenre);
            await _context.SaveChangesAsync();
            return _mapper.Map<GenreSong, SongGenreDto>(songGenre);
        }

        public async Task<bool> DeleteFeature(int GenreId)
        {
            try
            {
                GenreSong songGenre = await _context.GenreSong.Where(x => x.SongGenreId == GenreId).FirstOrDefaultAsync();
                if (songGenre == null)
                {
                    return false;
                }
                _context.GenreSong.Remove(songGenre);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SongGenreDto>> GetSongGenresForSong(int SongId)
        {
            IEnumerable<GenreSong> genres = await _context.GenreSong.Where(x=>x.SongId==SongId).ToListAsync();
            return _mapper.Map<List<SongGenreDto>>(genres);
        }

        public async Task<IEnumerable<SongGenreDto>> GetSongsWithGenre(int GenreId)
        {
            throw new NotImplementedException();
        }
    }
}
