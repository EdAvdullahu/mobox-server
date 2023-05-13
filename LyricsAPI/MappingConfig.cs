using AutoMapper;
using LyricsAPI.Models;
using LyricsAPI.Models.Dto;

namespace LyricsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Song, SongDto>().ReverseMap();
                config.CreateMap<Song, SongPut>().ReverseMap();
                config.CreateMap<Lyric, LyricDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
