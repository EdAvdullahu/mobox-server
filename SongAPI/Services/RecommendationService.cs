using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Services.Interface;
using System.Linq;

namespace SongAPI.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ApplicationDbContext _context;
        public RecommendationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<dynamic> GetRecommendations(Guid playlistId)
        {
            List<int> genres = new List<int>();
            List<int> artists = new List<int>();
            List<int> songs = new List<int>();

            // get playlist and its songs, genres, and artists
            Playlist playlist = await _context.Playlists
                .Include(p => p.Songs)
                .ThenInclude(s => s.Song).ThenInclude(s => s.Genres)
                .Include(p => p.Songs)
                .ThenInclude(s => s.Song).ThenInclude(s => s.Features)
                .FirstOrDefaultAsync(p => p.PlaylitId == playlistId);
            
            // populate lists with songs, genres and artists ids
            playlist.Songs.ToList().ForEach(s =>
            {
                songs.Add(s.SongId);
                s.Song.Genres.ToList().ForEach(genre =>
                {
                    genres.Add(genre.GenreId);
                });
                s.Song.Features.ToList().ForEach(feature =>
                {
                    artists.Add(feature.ArtistID);
                });
            });

            // calculate the weights for each genre and artist
            Dictionary<int, double> genreWeight = CalculateWeights(genres);
            Dictionary<int, double> artistWeight = CalculateWeights(artists);

            // get recommended songs based on the weights
            List<Song> recommendedSongs = _context.Songs
                .Include(s => s.Genres).Include(s => s.Features).Include(s => s.Streams)
                .Where(x => !songs.Contains(x.SongId) && (x.Genres.Any(g => genres.Contains(g.GenreId)) || x.Features.Any(g => artists.Contains(g.ArtistID))))
                .AsEnumerable()
                .OrderByDescending(s => CalculateSongWeight(s, genreWeight, artistWeight)).Take(10).ToList();

            return recommendedSongs;
        }
        private Dictionary<int, double> CalculateWeights(List<int> items)
        {
            Dictionary<int, double> weights = new Dictionary<int, double>();
            Dictionary<int, int> countFrequency = new Dictionary<int, int>();
            int totalCount = items.Count;
            double weightIncrement = 1.0 / totalCount;
            items.ForEach(item =>
            {
                if (countFrequency.ContainsKey(item))
                {
                    countFrequency[item]++;
                }
                else
                {
                    countFrequency.Add(item, 1);
                }
            });
            countFrequency.ToList().ForEach(item =>
            {
                weights.Add(item.Key, item.Value * weightIncrement);
            });

            return weights;
        }

        public double CalculateSongWeight(Song song, Dictionary<int, double> genreWeights, Dictionary<int, double> artistWeights)
        {
            double songWeight = 0.0;

            foreach (var genre in song.Genres)
            {
                if (genreWeights.ContainsKey(genre.GenreId))
                {
                    songWeight += genreWeights[genre.GenreId];
                }
            }

            foreach (var feature in song.Features)
            {
                if (artistWeights.ContainsKey(feature.ArtistID))
                {
                    songWeight += artistWeights[feature.ArtistID];
                }
            }

            return songWeight;
        }
    }
}
