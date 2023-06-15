using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using SongAPI.DbContexts;
using SongAPI.Models.Dto;
using SongAPI.Repository.Interface;

namespace SongAPI.Repository
{
    public class SongStatistics : ISongStatistics
    {
        private readonly ApplicationDbContext _context;
        public SongStatistics(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<SongDateStat>> GetSongStatByDates(DateTime startDate, DateTime endDate, int songId)
        {
            IEnumerable<SongDateStat> stats = await _context.Streams
        .Where(x => x.SongId == songId && x.ListenDateTime >= startDate && x.ListenDateTime <= endDate)
        .GroupBy(x => x.ListenDateTime.Date)
        .Select(x => new SongDateStat
        {
            Date = x.Key,
            NOStreams = x.Count()
        })
        .ToListAsync();

            var allDates = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                .Select(offset => startDate.AddDays(offset).Date);

            var missingDates = allDates.Except(stats.Select(s => s.Date));

            var missingStats = missingDates.Select(date => new SongDateStat
            {
                Date = date,
                NOStreams = 0
            });

            stats = stats.Concat(missingStats).OrderBy(s => s.Date);

            return stats;
        }

        public async Task<AllSongsStatisticsDto> GetSongStatisticsForArtist(int artistId)
        {
            AllSongsStatisticsDto all = new AllSongsStatisticsDto();
            all.ArtistId = artistId;
            IEnumerable<IndividualStatisticsDto> stats = _context.Artists.Include(x => x.Releases).ThenInclude(x => x.Songs).ThenInclude(z=>z.Streams).Include(x=>x.Releases).ThenInclude(x=>x.Songs).ThenInclude(x=>x.SongLikes).Where(x => x.ArtistId == artistId).SelectMany(x => x.Releases).SelectMany(x => x.Songs).Select(x => new IndividualStatisticsDto
            {
                SongId = x.SongId,
                ReleaseId = x.Release.ReleaseId,
                ReleaseName = x.Release.Title,
                SongName = x.Name,
                NOStreams = x.Streams.Count(s => s.SongId == x.SongId),
                LWNOStreams = x.Streams.Count(s => s.SongId == x.SongId && s.ListenDateTime >= DateTime.Now.AddDays(-7)),
                NOLikes = x.SongLikes.Count(s=>s.SongId == x.SongId),
            });
            all.Songs = stats;
            return all;
        }
    }
}
