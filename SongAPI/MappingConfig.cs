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
                config.CreateMap<Song,SongPutPost>().ReverseMap();
                config.CreateMap<Artist, ArtistPutPost>();
                config.CreateMap<ArtistPutPost, Artist>();
                config.CreateMap<Artist,ArtistDto>();
                config.CreateMap<ArtistDto, Artist>();
                config.CreateMap<Genre,GenreDto>().ReverseMap();
                config.CreateMap<Genre,GenrePutPost>().ReverseMap();
                config.CreateMap<Feature,FeatureDto>().ReverseMap();
                config.CreateMap<Feature, FeaturePutPost>().ReverseMap();
                config.CreateMap<SongGenre,SongGenrePutPost>().ReverseMap();
                config.CreateMap<SongGenre,SongGenreDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
