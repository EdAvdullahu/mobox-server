using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public FeatureRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FeatureDto> AddFeature(FeaturePutPost FeatureDto)
        {
            Feature feature = _mapper.Map<FeaturePutPost, Feature>(FeatureDto);
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return _mapper.Map<Feature, FeatureDto>(feature);
        }

        public async Task<bool> DeleteFeature(int FeatureId)
        {
            try
            {
                Feature feature = await _context.Features.Where(x => x.FeatureId == FeatureId).FirstOrDefaultAsync();
                if (feature == null)
                {
                    return false;
                }
                _context.Features.Remove(feature);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<FeatureDto>> GetFeatures()
        {
            IEnumerable<Feature> features = await _context.Features.ToListAsync();
            return _mapper.Map<IEnumerable<FeatureDto>>(features);
        }

        public async Task<IEnumerable<FeatureDto>> GetFeaturesBySongId(int SongId)
        {
            IEnumerable<Feature> features = await _context.Features.Where(x=>x.SongId==SongId).ToListAsync();
            return _mapper.Map<IEnumerable<FeatureDto>>(features);
        }
    }
}
