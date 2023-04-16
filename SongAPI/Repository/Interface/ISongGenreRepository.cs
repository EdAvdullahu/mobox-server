using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface ISongGenreRepository
    {
        Task<IEnumerable<SongGenreDto>> GetSongGenresForSong(int SongId);
        Task<IEnumerable<SongGenreDto>> GetSongsWithGenre(int GenreId);
        Task<SongGenreDto> AddGenre(SongGenrePutPost GenreDto);
        Task<bool> DeleteFeature(int GenreId);
    }
}
