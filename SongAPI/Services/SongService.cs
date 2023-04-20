using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.Data.SqlClient.Server;
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
        private IAudioService _audioService;
        private IImageService _imageService;

        public SongService(ISongRepository song,ISongGenreRepository songGenre, IFeatureRepository feature, IReleaseRepository release, IAudioService audioService, IImageService imageService)
        {
            _song = song;
            _songGenre = songGenre;
            _feature = feature;
            _release = release;
            _audioService = audioService;
            _imageService = imageService;
        }

        public async Task<ReleaseGetRequest> CreateRelease(ReleasePostRequest ReleaseRequest)
        {
            ReleaseGetRequest releaseRequest = new ReleaseGetRequest();
            /*releaseRequest.Songs = CreateSong(ReleaseRequest.Songs);
            ReleaseDto release = await _release.CreateUpdateRelease(ReleaseRequest.Release);
            releaseRequest.Release = release;*/
            return releaseRequest;
        }
        public async Task<SongGetRequest> CreateSong(SongPostRequest SongRequest)
        {
            ImageUploadResult image = await _imageService.AddImageAsync(SongRequest.Image);
            VideoUploadResult audio = await _audioService.UploadAudioAsync(SongRequest.Audio);
            SongPutPost song = new SongPutPost()
            {
                Name = SongRequest.Name,
                ImageUrl = image.Url + "",
                Path = audio.Url + "",
                LengthInSec = (int)audio.Duration,
                HasFeatures = SongRequest.Features.Count > 1,
                ReleaseId = SongRequest.ReleaseId,
                IsExplicite = SongRequest.IsExplicite,
            };
            SongDto songGet = await _song.CreateUpdateSong(song);
            List<FeatureDto> features = await addFeatures(SongRequest.Features, songGet.SongId);
            List<SongGenreDto> genres = await addGenre(SongRequest.Genres, songGet.SongId);
            SongGetRequest SongReturn = new SongGetRequest()
            {
                Song = songGet,
                Features = features,
                Genres = genres
            };
            return SongReturn;
            
        }
        private async Task<List<FeatureDto>> addFeatures(List<FeaturePutPost> Features, int SongId)
        {
            List<FeatureDto> features = new List<FeatureDto>();
            Features.ForEach(async feature =>
            {
                feature.SongId = SongId;
                FeatureDto featureDto = await _feature.AddFeature(feature);
                features.Add( featureDto);
            });
            return features;
        }
        private async Task<List<SongGenreDto>> addGenre(List<SongGenrePutPost> Genres, int SongId)
        {
            List<SongGenreDto> genres = new List<SongGenreDto>();
            Genres.ForEach(async genre =>
            {
                genre.SongId = SongId;
                SongGenreDto songGenreDto = await _songGenre.AddGenre(genre);
                genres.Add(songGenreDto);
            });
            return genres;
        }
    }
}
