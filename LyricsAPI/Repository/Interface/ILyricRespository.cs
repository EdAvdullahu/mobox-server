using LyricsAPI.Models.Dto;

namespace LyricsAPI.Repository.Interface
{
    public interface ILyricRespository
    {
        Task<IEnumerable<LyricDto>> GetLyrics();
        Task<LyricDto> GetLyricsById(Guid LyricsId);
        Task<LyricDto> GetLyricsBySongId(Guid SongId);
        Task<LyricDto> GetLyricsBySongApiId(int SongId);
        Task<LyricDto> CreateUpdateSong(LyricPut songPut);
        Task<bool> DeleteLyric(Guid lyricId);
    }
}
