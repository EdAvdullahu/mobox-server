using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public ArtistRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto)
        {
            Artist artist = _mapper.Map<ArtistPutPost, Artist>(aristDto);
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return _mapper.Map<Artist, ArtistDto>(artist);
        }
        public async Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto, int id)
        {
            Artist artist = await _context.Artists.Where(x=>x.ArtistId==id).FirstOrDefaultAsync();
            artist.Name = aristDto.Name;
            await _context.SaveChangesAsync();
            return _mapper.Map<Artist, ArtistDto>(artist);
        }


        public async Task<bool> DeleteArtist(int artistId)
        {
            try
            {
                Artist artist = await _context.Artists.Where(x => x.ArtistId == artistId).FirstOrDefaultAsync();
                if (artist == null)
                {
                    return false;
                }
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ArtistDto> GetArtistById(int artistId)
        {
            Artist artist = await _context.Artists.Where(x => x.ArtistId == artistId).FirstOrDefaultAsync();
            return _mapper.Map<ArtistDto>(artist);
        }
        public async Task<IEnumerable<ArtistDto>> GetArtists()
        {
            IEnumerable<Artist> artistList = await _context.Artists.ToListAsync();
            return _mapper.Map<List<ArtistDto>>(artistList);
        }
    }
}
