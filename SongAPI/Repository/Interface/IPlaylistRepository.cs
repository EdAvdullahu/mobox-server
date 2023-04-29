using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylists();
        Task<IEnumerable<PlaylistDto>> GetPlaylistsByUser(int userId);
        Task<PlaylistDto> GetPlaylistById(Guid playlistID);
        Task<PlaylistDto> CreateUpdatePlaylist(PlaylistPutPost aristDto);
        Task<PlaylistDto> CreateUpdateArtist(PlaylistPutPost aristDto, int id);
        Task<bool> DeletePlaylist(Guid artistId);
        Task<bool> AddCollaborator(CollaborationPutPost collab);
        Task<bool> RemoveCollaborator(int collabId);
        Task<bool> AddSong(SongPlaylistPutPost song);
        Task<bool> RemoveSong(SongPlaylistPutPost song);
    }
}
