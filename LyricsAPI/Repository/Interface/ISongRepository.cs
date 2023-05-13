using LyricsAPI.Models.Dto;

namespace LyricsAPI.Repository.Interface
{
    public interface ISongRepository
    {
        Task<IEnumerable<SongDto>> GetSongs();
        Task<SongDto> GetSongById(Guid Songid);
        Task<SongDto> GetSongByApiId(int Songid);
        Task<SongDto> CreateUpdateSong(SongPut songPut);
        Task<bool> DeleteSong(Guid songId);
    }

}
