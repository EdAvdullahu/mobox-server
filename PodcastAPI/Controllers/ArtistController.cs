﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PodcastAPI.Models.Dto;
using PodcastAPI.Repository.Interface;

namespace PodcastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        protected ResponseDto _response;
        private IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ArtistDto> artists = await _artistRepository.GetArtists();
                _response.Result = artists;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ArtistDto artist = await _artistRepository.GetArtistById(id);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> Post([FromBody] ArtistPutPost artistDto)
        {
            try
            {
                ArtistDto artist = await _artistRepository.CreateUpdateArtist(artistDto);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] ArtistPutPost artistDto, int id)
        {
            try
            {
                ArtistDto artist = await _artistRepository.CreateUpdateArtist(artistDto, id);
                _response.Result = artist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool deleted = await _artistRepository.DeleteArtist(id);
                _response.Result = deleted;
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
