using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylists();
        Task<IEnumerable<PlaylistDto>> GetPlaylistsByUser(int userId);
        Task<object> GetPlaylistById(Guid playlistID);
        Task<PlaylistDto> CreateUpdatePlaylist(PlaylistPutPost aristDto);
        Task<PlaylistDto> CreateUpdateArtist(PlaylistPutPost aristDto, int id);
        Task<bool> DeletePlaylist(Guid artistId);
        Task<bool> AddCollaborator(CollaborationPutPost collab);
        Task<bool> RemoveCollaborator(int collabId);
        Task<SongPlaylistDto> AddSong(SongPlaylistPutPost song);
        Task<bool> RemoveSong(int plsId);
        Task<bool> AddPlaylistToLiked(PlaylistLikePutPost plLike);
        Task<IEnumerable<CollaborationDto>> GetCollabs(Guid playlistId);
        Task<HasReadWritePerm> UserPermissionsForPlaylist(int userIt, Guid playlistId);
    }
}
