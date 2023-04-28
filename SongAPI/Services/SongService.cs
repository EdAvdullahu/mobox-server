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
        private IMapper _mapper;

        public SongService(ISongRepository song,ISongGenreRepository songGenre, IFeatureRepository feature, IReleaseRepository release, IAudioService audioService, IImageService imageService, IMapper mapper)
        {
            _song = song;
            _songGenre = songGenre;
            _feature = feature;
            _release = release;
            _audioService = audioService;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<ReleaseDto> CreateRelease(ReleasePostRequest ReleaseRequest)
        {
            ImageUploadResult image = await _imageService.AddImageAsync(ReleaseRequest.Image);
            ReleasePutPost releasePut = _mapper.Map<ReleasePutPost>(ReleaseRequest);
            releasePut.ReleaseDate = DateTime.Now;
            releasePut.ImageUrl = image.Url+"";
            releasePut.ReleaseType = ReleaseRequest.NumnerOfSongs <= 3 ? Models.ReleaseType.SINGLE : ReleaseRequest.NumnerOfSongs <= 6 ? Models.ReleaseType.EP : Models.ReleaseType.ALBUM; 
            ReleaseDto release = await _release.CreateUpdateRelease(releasePut);
            return release;
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
            for (int i = 0; i < Features.Count; i++)
            {
                FeaturePutPost feature = Features[i];
                feature.SongId = SongId;
                FeatureDto featureDto = await _feature.AddFeature(feature);
                features.Add(featureDto);
            }
            return features;
        }
        private async Task<List<SongGenreDto>> addGenre(List<SongGenrePutPost> Genres, int SongId)
        {
            List<SongGenreDto> genres = new List<SongGenreDto>();
            for(int i = 0; i< Genres.Count; i++)
            {
                SongGenrePutPost gen = Genres[i];
                gen.SongId = SongId;
                SongGenreDto songGenreDto = await _songGenre.AddGenre(gen);
                genres.Add(songGenreDto);
            }
            return genres;
        }
    }
}
