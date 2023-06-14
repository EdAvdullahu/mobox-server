using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodcastAPI.Controllers
{
    [Route("api/PodcastGenre")]
    [ApiController]
    public class PodcastGenreController : ControllerBase
    {
        protected ResponseDto _response;
        private IPodcastGenreRepository _repository;

        public PodcastGenreController(IPodcastGenreRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet("genre/{id}")]
        public async Task<IActionResult> GetPodcasts(int id)
        {
            try
            {
                IEnumerable<PodcastGenreDto> podcasts = await _repository.GetPodcastsWithGenre(id);
                _response.Result = podcasts;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("podcast/{id}")]
        public async Task<IActionResult> GetGenres(int id)
        {
            try
            {
                IEnumerable<PodcastGenreDto> genres = await _repository.GetPodcastGenresForPodcast(id);
                _response.Result = genres;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PodcastGenrePutPost podcastGenreDto)
        {
            try
            {
                PodcastGenreDto podcastGenre = await _repository.AddGenre(podcastGenreDto);
                _response.Result = podcastGenre;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool deleted = await _repository.DeleteGenre(id);
                _response.Result = deleted;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
