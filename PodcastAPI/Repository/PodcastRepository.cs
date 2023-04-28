using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.DbContexts;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;
using PodcastAPI.Services;
using PodcastAPI.Services.Interface;

namespace PodcastAPI.Repository
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IFileService _fileService;
        public PodcastRepository(ApplicationDbContext context, IMapper mapper, IFileService fileService) 
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }
        //done
        public async Task<PodcastDto> CreatePodcast(PodcastPutPost PodcastDto)
        {
            Podcast podcast = _mapper.Map<PodcastPutPost, Podcast>(PodcastDto);


            if (PodcastDto.Image != null)
            {
                var imageResult = await _fileService.AddImageAsync(PodcastDto.Image);
                podcast.PictureUrl = imageResult.SecureUrl.ToString();
                podcast.CloudanaryPublicId = imageResult.PublicId;
            }
            if (PodcastDto.Mp3 != null)
            {
                var Mp3Result = await _fileService.UploadMp3Async(PodcastDto.Mp3);
                podcast.Mp3Url = Mp3Result.SecureUrl.ToString();
                podcast.CloudanaryPublicMp3Id = Mp3Result.PublicId;
            }
            podcast.ReleaseDate = DateTime.Now;
            podcast.Length = TimeSpan.FromSeconds(PodcastDto.LengthInSec);
            _context.Podcasts.Add(podcast);
            await _context.SaveChangesAsync();
            return _mapper.Map<Podcast, PodcastDto>(podcast);
        }

        public async Task<bool> DeletePodcast(int Id)
        {
            try
            {
                Podcast podcast = await _context.Podcasts.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (podcast == null)
                {
                    return false;
                }
                _context.Podcasts.Remove(podcast);
                await _context.SaveChangesAsync();
                _fileService.DeleteImageAsync(podcast.CloudanaryPublicId);
                _fileService.DeleteImageAsync(podcast.CloudanaryPublicMp3Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //done
        public async Task<PodcastDto> GetPodcastById(int Id)
        {
            Podcast podcast = await _context.Podcasts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<PodcastDto>(podcast);
           
        }
        //done
        public async Task<IEnumerable<PodcastDto>> GetPodcasts()
        {
            IEnumerable<Podcast> podcasts = await _context.Podcasts.ToListAsync();
            return _mapper.Map<List<PodcastDto>>(podcasts);
        }

        public Task<PodcastDto> UpdatePodcast(PodcastPutPost PodcastDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
