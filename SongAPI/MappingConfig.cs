using AutoMapper;
using SongAPI.Models;
using SongAPI.Models.Dto;

namespace SongAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SongDto, Song>();
                config.CreateMap<Song, SongDto>();
            });
            return mappingConfig;
        }
    }
}
