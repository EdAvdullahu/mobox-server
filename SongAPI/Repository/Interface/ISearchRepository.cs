using SongAPI.Models.Dto;

namespace SongAPI.Repository.Interface
{
    public interface ISearchRepository
    {
        object SearchByName(string[] name);
        Task<List<object>> SearchSongByGenreAsync(int[] genres);
        Task<IEnumerable<dynamic>> FilterByGere(string genres);
        Task<IEnumerable<dynamic>> FilterPlaylist(string[] name, int userId);
    }
}
