using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using SongAPI.Services.Interface;
using System.Collections.Concurrent;

namespace SongAPI.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private IImageService _imageService;
        public ArtistRepository(ApplicationDbContext context, IMapper mapper, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<ArtistDto> CreateUpdateArtist(ArtistPutPost aristDto)
        {
            string ImageUrl = _imageService.AddImageAsync(aristDto.Image)+"";
            Artist artist = _mapper.Map<ArtistPutPost, Artist>(aristDto);
            artist.ImageUrl = ImageUrl;
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

        public async Task<dynamic> GetArtist(int artistId)
        {
            var artist = await _context.Artists
                .Where(x => x.ArtistId == artistId)
                .Select(x => new
                {
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    ImgUrl = x.ImageUrl,
                    Features = x.Features.Where(x => x.FeatureRole != Models.FeatureRole.MAIN)
                        .Select(r => new
                        {
                            SongId = r.SongId,
                            Name = r.Song.Name,
                            ReleaseDate = r.Song.ReleaseDate,
                            Length = r.Song.Length,
                            Path = r.Song.Path,
                            ImageUrl = r.Song.ImageUrl,
                            Release = new
                            {
                                ReleaseId = r.Song.ReleaseId,
                                Title = r.Song.Release.Title,
                            },
                            Features = r.Song.Features.Select(f => new
                            {
                                ArtistId = f.Artist.ArtistId,
                                Name = f.Artist.Name
                            }).ToList(),
                            Genres = r.Song.Genres.Select(g => new
                            {
                                GenreId = g.Genre.GenreId,
                                Name = g.Genre.Name,
                                Description = g.Genre.Description
                            }).ToList()
                        }).ToList(),
                    Releases = x.Releases
                        .Select(r => new
                        {
                            ReleaseId = r.ReleaseId,
                            ReleaseType = r.ReleaseType,
                            Title = r.Title,
                            ReleaseDate = r.ReleaseDate,
                            ImageUrl = r.ImageUrl,
                            Description = r.Description,
                            Songs = r.Songs
                                .Select(s => new
                                {
                                    SongId = s.SongId,
                                    Name = s.Name,
                                    ImageUrl = s.ImageUrl,
                                    Length = s.Length,
                                    Path = s.Path,
                                    ReleaseDate = s.ReleaseDate,
                                    IsExplicite = s.IsExplicite,
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
                        }).ToList()
                })
                .SingleOrDefaultAsync();

            return artist;
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
