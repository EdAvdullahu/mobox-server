using AutoMapper;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using SongAPI.Services.Interface;

namespace SongAPI.Services
{
    public class SongService : ISongService
    {
        private ISongRepository _song;
        private ISongGenreRepository _songGenre;
        private IFeatureRepository _feature;
        private IReleaseRepository _release;

        public SongService(ISongRepository song, ISongGenreRepository songGenre, IFeatureRepository feature, IReleaseRepository release)
        {
            _song = song;
            _songGenre = songGenre;
            _feature = feature;
            _release = release;
        }

        public async Task<ReleaseGetRequest> CreateRelease(ReleasePostRequest ReleaseRequest)
        {
            ReleaseGetRequest releaseRequest = new ReleaseGetRequest();
            releaseRequest.Songs = CreateSong(ReleaseRequest.Songs);
            ReleaseDto release = await _release.CreateUpdateRelease(ReleaseRequest.Release);
            releaseRequest.Release = release;
            return releaseRequest;
        }
        private List<SongGetRequest> CreateSong(List<SongPostRequest> SongRequest)
        {
            List<SongGetRequest> Songs = new List<SongGetRequest>();
            SongRequest.ForEach(song =>
            {
                SongGetRequest tempSongGetRequest = new SongGetRequest();
                tempSongGetRequest.Song = _song.CreateUpdateSong(song.Song).Result;
                tempSongGetRequest.Features = addFeatures(song.Features, tempSongGetRequest.Song.SongId);
                tempSongGetRequest.Genres = addGenre(song.Genres, tempSongGetRequest.Song.SongId);
                Songs.Add(tempSongGetRequest);
            });
            return Songs;
        }
        private List<FeatureDto> addFeatures(List<FeaturePutPost> Features, int SongId)
        {
            List<FeatureDto> features = new List<FeatureDto>();
            Features.ForEach(feature =>
            {
                feature.SongId = SongId;
                features.Add(_feature.AddFeature(feature).Result);
            });
            return features;
        }
        private List<SongGenreDto> addGenre(List<SongGenrePutPost> Genres, int SongId)
        {
            List<SongGenreDto> genres = new List<SongGenreDto>();
            Genres.ForEach(genre =>
            {
                genre.SongId = SongId;
                genres.Add(_songGenre.AddGenre(genre).Result);
            });
            return genres;
        }
    }
}
