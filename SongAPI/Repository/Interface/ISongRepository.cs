using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface ISongRepository
    {
        Task<IEnumerable<SongDto>> GetSongs();
        Task<SongDto> GetSongById(int SongId);
        Task<SongDto> CreateUpdateSong(SongPutPost songDto);
        Task<SongDto> CreateUpdateSong(SongPutPost songDto, int id);
        Task<bool> DeleteSong(int SongId);
    }
}
