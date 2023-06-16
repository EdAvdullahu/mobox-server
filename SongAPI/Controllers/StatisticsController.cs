using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ISongStatistics _songStatistics;
        private readonly IReleaseStatistics _releaseStatistics;
        private readonly IUserStatistics _userStatistics;
        private readonly ResponseDto _response;
        public StatisticsController(ISongStatistics songStatistics, IReleaseStatistics releaseStatistics, IUserStatistics userStatistics)
        {
            _songStatistics = songStatistics;
            _response = new ResponseDto();
            _releaseStatistics = releaseStatistics;
            _userStatistics = userStatistics;
        }
        [HttpGet("artist/all-songs/{id}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> Get(int id)
        {
            try
            {
                AllSongsStatisticsDto statistics = await _songStatistics.GetSongStatisticsForArtist(id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("song/by-dates/{id}/{start_date}/{end_date}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> GetSongStatByDates(int id, DateTime start_date, DateTime end_date)
        {
            try
            {
                IEnumerable<SongDateStat> statistics = await _songStatistics.GetSongStatByDates(start_date, end_date, id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("artist/all-releases/{id}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> GetReleases(int id)
        {
            try
            {
                AllReleasesStatisticsDto statistics = await _releaseStatistics.GetReleaseStatisticsForArtist(id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("release/by-dates/{id}/{start_date}/{end_date}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> GetReleaseStatByDates(int id, DateTime start_date, DateTime end_date)
        {
            try
            {
                ReleaseByDates statistics = await _releaseStatistics.GetReleaseStatByDates(start_date, end_date, id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("artist/main/{id}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> GetArtistStatistics(int id)
        {
            try
            {
                ArtistsStatisticsDto statistics = await _userStatistics.GetStatisticsForArtist(id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("artist/top-listeners/{id}")]
        [Authorize(Roles = "Artist, Admin")]
        public async Task<object> GetTopListeners(int id)
        {
            try
            {
                TopListenersDto statistics = await _userStatistics.GetTopListeners(id);
                _response.Result = statistics;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
