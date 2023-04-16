using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

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
            SongGenre songGenre = _mapper.Map<SongGenrePutPost, SongGenre>(GenreDto);
            _context.SongGenres.Add(songGenre);
            await _context.SaveChangesAsync();
            return _mapper.Map<SongGenre, SongGenreDto>(songGenre);
        }

        public async Task<bool> DeleteFeature(int GenreId)
        {
            try
            {
                SongGenre songGenre = await _context.SongGenres.Where(x => x.SongGenreId == GenreId).FirstOrDefaultAsync();
                if (songGenre == null)
                {
                    return false;
                }
                _context.SongGenres.Remove(songGenre);
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SongGenreDto>> GetSongsWithGenre(int GenreId)
        {
            throw new NotImplementedException();
        }
    }
}
