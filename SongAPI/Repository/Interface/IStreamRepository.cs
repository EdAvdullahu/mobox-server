using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface IStreamRepository
    {
        public Task<bool> StreamSong(PlaySongCreateDto stream);
        public Task<IEnumerable<PlaySongDto>> getUserStreams(int userId);
        public Task<IEnumerable<PlaySongDto>> getSongStreams(int songId);
    }
}
