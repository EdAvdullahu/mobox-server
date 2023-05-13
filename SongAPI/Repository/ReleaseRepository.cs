using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using System.Reflection.Metadata.Ecma335;

namespace SongAPI.Repository
{
    public class ReleaseRepository : IReleaseRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public ReleaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReleaseDto> CreateUpdateRelease(ReleasePutPost ReleaseDto)
        {
            Release release = _mapper.Map<ReleasePutPost, Release>(ReleaseDto);
            _context.Releases.Add(release);
            await _context.SaveChangesAsync();
            return _mapper.Map<Release, ReleaseDto>(release);
        }

        public async Task<ReleaseDto> CreateUpdateRelease(ReleasePutPost ReleaseDto, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteRelease(int ReleaseId)
        {
            try
            {
                Release release = await _context.Releases.Where(x => x.ReleaseId== ReleaseId).FirstOrDefaultAsync();
                if (release == null)
                {
                    return false;
                }
                _context.Releases.Remove(release);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ReleaseDto>> GetReleaseByArtist(int ArtistsId)
        {
            IEnumerable<Release> releases = await _context.Releases.Where(x => x.ArtistId == ArtistsId).ToListAsync();
            return _mapper.Map<List<ReleaseDto>>(releases);
        }

        public async Task<dynamic> GetReleaseById(int ReleaseId)
        {
            var release = await _context.Releases
        .Where(r => r.ReleaseId == ReleaseId)
        .Select(r => new
        {
            ReleaseId = r.ReleaseId,
            ReleaseType = r.ReleaseType,
            Title = r.Title,
            ReleaseDate = r.ReleaseDate,
            ImageUrl = r.ImageUrl,
            Description = r.Description,
            Songs = r.Songs.Select(s => new
            {
                SongId = s.SongId,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Length = s.Length,
                Path = s.Path,
                ReleaseDate = s.ReleaseDate,
                IsExplicit = s.IsExplicite,
                HasFeatures = s.HasFeatures,
                Features = s.Features.Select(f => new
                {
                    ArtistId = f.Artist.ArtistId,
                    Name = f.Artist.Name
                }).ToList(),
                Genres = s.Genres.Select(g => new
                {
                    GenreId = g.Genre.GenreId,
                    Name = g.Genre.Name,
                    Description = g.Genre.Description
                }).ToList()
            }).ToList()
        })
        .SingleOrDefaultAsync();

            return release;
        }

        public async Task<IEnumerable<ReleaseDto>> GetReleases()
        {
            IEnumerable<Release> releases = await _context.Releases.ToListAsync();
            return _mapper.Map<List<ReleaseDto>>(releases);
        }
    }
}
