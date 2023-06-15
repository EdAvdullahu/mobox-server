using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;
using System.Net.Sockets;

namespace SongAPI.Repository
{
    public class UserStatistics : IUserStatistics
    {
        private readonly ApplicationDbContext _context;
        public UserStatistics(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ArtistsStatisticsDto> GetStatisticsForArtist(int artistId)
        {
            Artist artist = await _context.Artists
                .Include(x=>x.Features).ThenInclude(x=>x.Song).ThenInclude(x=>x.Streams)
                .Include(x=>x.Features).ThenInclude(x=>x.Song).ThenInclude(x=>x.SongLikes)
                .Where(x=>x.ArtistId==artistId).FirstOrDefaultAsync();
            IEnumerable<int> streams = getStreams(artist);
            IEnumerable<int> likes = getLikes(artist);
            IEnumerable<int> listeners = getListeners(artist);
            ArtistsStatisticsDto artistStatisticsDto = new ArtistsStatisticsDto
            {
                ArtistId = artistId,
                ArtistName = artist.Name,
                NOStreams = streams.First(),
                ALLStreams = streams.Last(),
                NOLikes = likes.First(),
                ALLLikes = likes.Last(),
                MOListeners = listeners.First(),
                ALListeners = listeners.Last()
            };
            return artistStatisticsDto;
        }
        private static IEnumerable<int> getStreams(Artist artist)
        {
            int streams = 0;
            int allStreams = 0;
            foreach (Feature feature in artist.Features)
            {
                streams += feature.Song.Streams.Count(x => x.SongId == feature.SongId && feature.FeatureRole==0);
                allStreams += feature.Song.Streams.Count(x => x.SongId == feature.SongId);
            }
            IEnumerable<int> streamsE = new List<int> { streams, allStreams };
            return streamsE;
        }
        private static IEnumerable<int> getLikes(Artist artist)
        {
            int likes = 0;
            int allLikes = 0;
            foreach (Feature feature in artist.Features)
            {
                likes += feature.Song.SongLikes.Count(x => x.SongId == feature.SongId && feature.FeatureRole == 0);
                allLikes += feature.Song.SongLikes.Count(x => x.SongId == feature.SongId);
            }
            IEnumerable<int> like = new List<int> { likes, allLikes };
            return like;
        }
        public static IEnumerable<int> getListeners(Artist artist)
        {
            int listeners = 0;
            int allListeners = 0;
            foreach (Feature feature in artist.Features)
            {
                listeners += feature.Song.Streams.Where(x => x.SongId == feature.SongId && feature.FeatureRole == 0)
                    .Select(x => x.UserId)
                    .Distinct()
                    .Count();

                allListeners += feature.Song.Streams.Where(x => x.SongId == feature.SongId)
                    .Select(x => x.UserId)
                    .Distinct()
                    .Count();
            }

            IEnumerable<int> listener = new List<int> { listeners, allListeners };
            return listener;
        }

        public async Task<TopListenersDto> GetTopListeners(int artistId)
        {
            Artist artist = await _context.Artists
                .Include(x => x.Features).ThenInclude(x => x.Song).ThenInclude(x => x.Streams).ThenInclude(x=> x.User)
                .Include(x => x.Features).ThenInclude(x => x.Song).ThenInclude(x => x.SongLikes).ThenInclude(x => x.User)
                .Where(x => x.ArtistId == artistId).FirstOrDefaultAsync();
            Dictionary<int, string> streamers = getStreamerData(artist);
            Dictionary<int, int> userStreams = getUsersStreams(artist);
            Dictionary<int, int> userLikes = getUsersLikes(artist);
            IEnumerable<ListenerDto> listeners = new List<ListenerDto> ();
            streamers.ToList().ForEach(streamer =>
            {
                ListenerDto listener = new ListenerDto
                {
                    UserId = streamer.Key,
                    UserName = streamer.Value,
                    NOStreams = userStreams[streamer.Key],
                    NOLikes = userLikes[streamer.Key]
                };
                listeners = listeners.Append(listener);
            });
            TopListenersDto topListenersDto = new TopListenersDto
            {
                ArtistId = artistId,
                ArtistName = artist.Name,
                TopListeners = listeners.OrderByDescending(x=>x.NOStreams).Take(10)
            };
            return topListenersDto;
        }
        private static Dictionary<int, int> getUsersStreams(Artist artist)
        {
            Dictionary<int, int> userStreams = new Dictionary<int, int>();
            artist.Features.ToList().ForEach(x =>
            {
                x.Song.Streams.ToList().ForEach(y =>
                {
                    if (y.SongId == x.SongId && x.FeatureRole == 0)
                    {
                        if (userStreams.ContainsKey(y.UserId))
                        {
                            userStreams[y.UserId] += 1;
                        }
                        else
                        {
                            userStreams.Add(y.UserId, 1);
                        }
                    }
                });
            });
            return userStreams;
        }
        private static Dictionary<int, int> getUsersLikes(Artist artist)
        {
            Dictionary<int, int> userStreams = new Dictionary<int, int>();
            artist.Features.ToList().ForEach(x =>
            {
                x.Song.SongLikes.ToList().ForEach(y =>
                {
                    if (y.SongId == x.SongId)
                    {
                        if (userStreams.ContainsKey(y.UserId))
                        {
                            userStreams[y.UserId] += 1;
                        }
                        else
                        {
                            userStreams.Add(y.UserId, 1);
                        }
                    }
                });
            });
            return userStreams;
        }
        private static Dictionary<int,string> getStreamerData(Artist artist)
        {
            Dictionary<int, string> streamers = new Dictionary<int, string>();
            artist.Features.ToList().ForEach(x =>
            {
                x.Song.Streams.ToList().ForEach(y =>
                {
                    if (y.SongId == x.SongId && x.FeatureRole == 0)
                    {
                        if (streamers.ContainsKey(y.UserId))
                        {
                            
                        }
                        else
                        {
                            streamers.Add(y.UserId, y.User.UserName);
                        }
                    }
                });
            });
            return streamers;
        }
    }
}
