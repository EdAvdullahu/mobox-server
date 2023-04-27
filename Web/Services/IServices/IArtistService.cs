using Web.Models.Dto;

namespace Web.Services.IServices
{
    public interface IArtistService
    {
        Task<T> GetArtists<T>(string token);
        Task<T> GetArtistById<T>(int artistId, string token);
        Task<T> CreateUpdateArtist<T>(ArtistPutPost aristDto,string token);
        Task<T> CreateUpdateArtist<T>(ArtistPutPost aristDto, int id,string token);
        Task<T> DeleteArtist<T>(int artistId,string token);
        Task<T> GetArtist<T>(int artistId,string token);
    }
}
