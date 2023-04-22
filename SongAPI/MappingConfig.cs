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
                config.CreateMap<GenreSong, SongGenrePutPost>().ReverseMap();
                config.CreateMap<GenreSong, SongGenreDto>().ReverseMap();
                config.CreateMap<Release,ReleaseDto>().ReverseMap();
                config.CreateMap<Release, ReleasePutPost>().ReverseMap();
                config.CreateMap<ReleasePutPost,ReleasePostRequest>().ReverseMap();
                /*config.CreateMap<Feature, Artist>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Artist.Name))
                .ReverseMap();
                config.CreateMap<Genre, SongGenre>().ReverseMap();*/

            });
            return mappingConfig;
        }
    }
}
