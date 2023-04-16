using SongAPI.Models.Dto;

namespace SongAPI.Repository
{
    public interface ISongRepository
    {
        Task<IEnumerable<SongDto>> GetSongs();
        Task<SongDto> GetSongById(int SongId);
        Task<SongDto> CreateUpdateSong(SongDto songDto);
        Task<bool> DeleteSong (int SongId);
    }
}
