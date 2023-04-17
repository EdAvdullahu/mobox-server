using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public GenreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto)
        {
            Genre genre= _mapper.Map<GenrePutPost, Genre>(GenreDto);
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return _mapper.Map<Genre, GenreDto>(genre);
        }

        public async Task<GenreDto> CreateUpdateGenre(GenrePutPost GenreDto, int id)
        {
            Genre genre = await _context.Genres.Where(x => x.GenreId == id).FirstOrDefaultAsync();
            genre = _mapper.Map<GenrePutPost, Genre>(GenreDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Genre, GenreDto>(genre);
        }

        public async Task<bool> DeleteGenre(int GenreId)
        {
            try
            {
                Genre genre = await _context.Genres.Where(x => x.GenreId == GenreId).FirstOrDefaultAsync();
                if (genre == null)
                {
                    return false;
                }
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<GenreDto> GetGenreByID(int GenreId)
        {
            Genre genre = await _context.Genres.Where(x => x.GenreId == GenreId).FirstOrDefaultAsync();
            return _mapper.Map<GenreDto>(genre);
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            IEnumerable<Genre> genreList = await _context.Genres.ToListAsync();
            return _mapper.Map<List<GenreDto>>(genreList);
        }
    }
}
