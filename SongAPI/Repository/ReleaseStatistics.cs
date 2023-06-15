using Microsoft.EntityFrameworkCore;
using SongAPI.DbContexts;
using SongAPI.Models.Dto;
using SongAPI.Models;
using SongAPI.Repository.Interface;
using Microsoft.AspNetCore.Components;

namespace SongAPI.Repository
{
    public class ReleaseStatistics : IReleaseStatistics
    {
        private readonly ApplicationDbContext _context;
        public ReleaseStatistics(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AllReleasesStatisticsDto> GetReleaseStatisticsForArtist(int artistId)
        {
            AllReleasesStatisticsDto all = new AllReleasesStatisticsDto();
            all.ArtistId = artistId;
            IEnumerable<IndividualReleaseStatisticsDto> stats = _context.Artists.Include(x => x.Releases).ThenInclude(x => x.Songs).ThenInclude(z => z.Streams).Where(x => x.ArtistId == artistId).SelectMany(x => x.Releases).Select(x => new IndividualReleaseStatisticsDto
            {
                ReleaseId = x.ReleaseId,
                ReleaseName = x.Title,
                NOShares = 0,
                LMNOStreams = getAllStreams(x, DateTime.Now.AddDays(-30)),
                NOStreams = getAllStreams(x),
                LWNOStreams = getAllStreams(x, DateTime.Now.AddDays(-7)),
            });
            all.Releases = stats;
            return all;
        }
        private static int getAllStreams(Release release)
        {
            int streams = 0;
            foreach (Song song in release.Songs)
            {
                streams += song.Streams.Count(x=>x.SongId == song.SongId);
            }
            return streams;
        }
        private static int getAllStreams(Release release, DateTime dateTime)
        {
            int streams = 0;
            foreach (Song song in release.Songs)
            {
                streams += song.Streams.Count(x => x.SongId == song.SongId && x.ListenDateTime >= dateTime);
            }
            return streams;
        }

        public async Task<ReleaseByDates> GetReleaseStatByDates(DateTime startDate, DateTime endDate, int releaseId)
        {
            IEnumerable<SongDateStat> releaseStats = await _context.Streams.Include(x => x.Song)
                .Where(x => x.Song.ReleaseId == releaseId && x.ListenDateTime >= startDate && x.ListenDateTime <= endDate)
                .GroupBy(x => x.ListenDateTime.Date)
                .Select(x => new SongDateStat
                {
                    Date = x.Key,
                    NOStreams = x.Count()
                })
                .ToListAsync();
            var allDates = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                .Select(offset => startDate.AddDays(offset).Date);

            var missingDates = allDates.Except(releaseStats.Select(s => s.Date));

            var missingStats = missingDates.Select(date => new SongDateStat
            {
                Date = date,
                NOStreams = 0
            });

            releaseStats = releaseStats.Concat(missingStats).OrderBy(s => s.Date);

            List<SongReleaseByDate> songReleaseByDates = new List<SongReleaseByDate>();
            Release release = await _context.Releases.Include(x => x.Songs).FirstOrDefaultAsync(x => x.ReleaseId == releaseId);

            foreach (var song in release.Songs)
            {
                IEnumerable<SongDateStat> songStats = await _context.Streams.Include(x => x.Song)
                    .Where(x => x.SongId == song.SongId && x.ListenDateTime >= startDate && x.ListenDateTime <= endDate)
                    .GroupBy(x => x.ListenDateTime.Date)
                    .Select(x => new SongDateStat
                    {
                        Date = x.Key,
                        NOStreams = x.Count()
                    })
                    .ToListAsync();

                var missingDatesS = allDates.Except(songStats.Select(s => s.Date));

                var missingStatsS = missingDatesS.Select(date => new SongDateStat
                {
                    Date = date,
                    NOStreams = 0
                });

                songStats = songStats.Concat(missingStats).OrderBy(s => s.Date);

                songReleaseByDates.Add(new SongReleaseByDate
                {
                    SongID = song.SongId,
                    SongName = song.Name,
                    ReleaseStats = songStats
                });
            }

            ReleaseByDates stats = new ReleaseByDates
            {
                Release = releaseStats,
                Songs = songReleaseByDates
            };

            return stats;
        }
    }
}
