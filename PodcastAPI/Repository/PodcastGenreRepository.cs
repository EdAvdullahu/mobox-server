using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.DbContexts;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;
using PodcastAPI.Repository.Interface;
using PodcastGenre = PodcastAPI.Models.PodcastGenre;

namespace PodcastAPI.Repository
{
    public class PodcastGenreRepository : IPodcastGenreRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public PodcastGenreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PodcastGenreDto> AddGenre(PodcastGenrePutPost genreDto)
        {
            PodcastGenre podcastGenre = _mapper.Map<PodcastGenrePutPost, PodcastGenre>(genreDto);
            _context.PodcastGenres.Add(podcastGenre);
            await _context.SaveChangesAsync();
            return _mapper.Map<PodcastGenre, PodcastGenreDto>(podcastGenre);
        }

        public async Task<bool> DeleteGenre(int genreId)
        {
            try
            {
                PodcastGenre podcastGenre = await _context.PodcastGenres.Where(x => x.Id == genreId).FirstOrDefaultAsync();
                if (podcastGenre == null)
                {
                    return false;
                }
                _context.PodcastGenres.Remove(podcastGenre);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PodcastGenreDto>> GetPodcastGenresForPodcast(int podcastId)
        {
            IEnumerable<PodcastGenre> genres = await _context.PodcastGenres.Where(x => x.Id == podcastId).ToListAsync();
            return _mapper.Map<List<PodcastGenreDto>>(genres);
        }

        public async Task<IEnumerable<PodcastGenreDto>> GetPodcastsWithGenre(int genreId)
        {
            throw new NotImplementedException();
        }
    }
}
