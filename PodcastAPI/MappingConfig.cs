using AutoMapper;
using PodcastAPI.Models;
using PodcastAPI.Models.Dto;

namespace PodcastAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Artist, ArtistPutPost>();
                config.CreateMap<Artist, ArtistDto>();
                config.CreateMap<Artist, ArtistDto>().ReverseMap();
                config.CreateMap<ArtistPutPost, Artist>();
                config.CreateMap<Podcast, PodcastDto>();
                config.CreateMap<PodcastPutPost, Podcast>();
                config.CreateMap<Genre, GenreDto>().ReverseMap();
                config.CreateMap<Genre, GenrePutPost>().ReverseMap();
                config.CreateMap<User, UserPutPost>().ReverseMap();
                config.CreateMap<User, UserDto>().ReverseMap();
                config.CreateMap<Playlist, PlaylistDto>().ReverseMap();
                config.CreateMap<Playlist, PlaylistPutPost>().ReverseMap();
                config.CreateMap<PlaylistPodcast, PodcastPlaylistDto>().ReverseMap();
                config.CreateMap<PlaylistPodcast, PodcastPlaylistPutPost>().ReverseMap();
                config.CreateMap<User, WhoAmI>().ReverseMap();
                config.CreateMap<PlaylistLike, PlaylistLikeDto>().ReverseMap();
                config.CreateMap<PlaylistLike, PlaylistLikePutPost>().ReverseMap();
                config.CreateMap<PodcastLike, PodcastLikeDTO>().ReverseMap();
                config.CreateMap<PodcastLike, PodcastLikePutPost>().ReverseMap();

                /*config.CreateMap<Feature, Artist>()
                /*config.CreateMap<Feature, Artist>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Artist.Name))
                .ReverseMap();
                config.CreateMap<Genre, SongGenre>().ReverseMap();*/

            });
            return mappingConfig;
        }
    }
}
