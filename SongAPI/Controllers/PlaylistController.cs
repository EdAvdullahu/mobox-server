using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        protected ResponseDto _response;
        private IPlaylistRepository _playlistRepository;
        public PlaylistController(IPlaylistRepository repo)
        {
            _playlistRepository = repo;
            _response = new ResponseDto();
        }

        [HttpGet]

        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PlaylistDto> playlists = await _playlistRepository.GetPlaylists();
                _response.Result = playlists;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}")]
        public async Task<object> Get(Guid id)
        {
            try
            {
                object playlist = await _playlistRepository.GetPlaylistById(id);
                _response.Result = playlist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("user/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                IEnumerable<PlaylistDto> playlists = await _playlistRepository.GetPlaylistsByUser(id);
                _response.Result = playlists;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("playlist")]
        public async Task<object> Post(PlaylistPutPost playlistDto)
        {
            try
            {
                PlaylistDto playlist = await _playlistRepository.CreateUpdatePlaylist(playlistDto);
                _response.Result = playlist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("like")]
        public async Task<object> LikePlaylist(PlaylistLikePutPost playlistLikeDto)
        {
            try
            {
                bool liked = await _playlistRepository.AddPlaylistToLiked(playlistLikeDto);
                _response.Result = liked;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("collab")]
        public async Task<object> AddCollab(CollaborationPutPost collab)
        {
            try
            {
                bool added = await _playlistRepository.AddCollaborator(collab);
                _response.Result = added;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("song")]
        public async Task<object> AddSong(SongPlaylistPutPost song)
        {
            try
            {
                SongPlaylistDto added = await _playlistRepository.AddSong(song);
                _response.Result = added;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("collab/{collabId}")]
        public async Task<object> RemoveCollab(int collabId)
        {
            try
            {
                bool removed = await _playlistRepository.RemoveCollaborator(collabId);
                _response.Result = removed;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("song")]
        public async Task<object> RemoveSong(int id)
        {
            try
            {
                bool removed = await _playlistRepository.RemoveSong(id);
                _response.Result = removed;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        public async Task<object> Delete(Guid id)
        {
            try
            {
                bool deleted = await _playlistRepository.DeletePlaylist(id);
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
