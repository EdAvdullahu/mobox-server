using PodcastAPI.Models.Dto;

namespace PodcastAPI.Repository.Interface
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylists();
        Task<IEnumerable<PlaylistDto>> GetPlaylistsByUser(int userId);
        Task<object> GetPlaylistById(Guid playlistID);
        Task<PlaylistDto> CreateUpdatePlaylist(PlaylistPutPost aristDto);
        Task<bool> DeletePlaylist(Guid artistId);
        Task<PodcastPlaylistDto> AddPodcastToPlaylist(PodcastPlaylistPutPost podcast);
        Task<bool> RemovePodcastFromPlaylist(int Id);
        Task<bool> AddPlaylistToLiked(PlaylistLikePutPost plLike);
    }
}
